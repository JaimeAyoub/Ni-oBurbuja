using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Tilemap tilemap; // Tilemap base
    public Tile plataformaTile; // Tile para plataformas
    public Tile paredTile; // Tile para las paredes
    public Tile obstaculoTile; // Tile para obst�culos
    public GameObject enemigoPrefab; // Prefab para los enemigos

    public int anchoNivel = 10; // Ancho del nivel en tiles
    public float frecuenciaPlataformas = 2f; // Espaciado m�nimo entre plataformas
    public float alturaMaximaPlataforma = 4f; // Altura m�xima entre plataformas
    public float probabilidadEnemigo = 0.3f; // Probabilidad de que un enemigo aparezca en una plataforma
    public float probabilidadObstaculo = 0.2f; // Probabilidad de que un obst�culo aparezca en una plataforma
    public int anchuraPlataforma = 3; // Anchura de las plataformas en tiles

    public Transform jugador; // Referencia al jugador
    public float distanciaParaGenerar = 10f; // Distancia desde el borde inferior para generar m�s nivel

    private float ultimaAlturaGenerada = 0; // Altura m�s baja generada hasta ahora

    void Start()
    {
        // Generar la primera secci�n del nivel
        GenerarSeccion(0, -20); // Generar hacia abajo inicialmente
        ultimaAlturaGenerada = -20;
    }

    void Update()
    {
        // Revisar si el jugador est� lo suficientemente cerca del borde inferior para generar m�s nivel
        if (jugador.position.y < ultimaAlturaGenerada + distanciaParaGenerar)
        {
            GenerarSeccion(ultimaAlturaGenerada, ultimaAlturaGenerada - 20); // Generar m�s nivel hacia abajo
            ultimaAlturaGenerada -= 20; // Actualizar el rastreo de la altura generada
        }
    }

    void GenerarSeccion(float inicioAltura, float finAltura)
    {
        float yPos = inicioAltura;

        // Generar plataformas, enemigos y obst�culos
        while (yPos > finAltura) // Invertido porque generamos hacia abajo
        {
            // Generar una posici�n aleatoria para la plataforma dentro del ancho del nivel
            int xCentro = Random.Range(-anchoNivel / 2, anchoNivel / 2);

            // Generar tiles consecutivos para una plataforma m�s ancha
            for (int xOffset = -anchuraPlataforma / 2; xOffset <= anchuraPlataforma / 2; xOffset++)
            {
                Vector3Int plataformaPos = new Vector3Int(xCentro + xOffset, Mathf.RoundToInt(yPos), 0);
                tilemap.SetTile(plataformaPos, plataformaTile);
            }

            // Colocar enemigo con una probabilidad (en el centro de la plataforma)
            if (Random.value < probabilidadEnemigo)
            {
                Vector3 enemigoWorldPos = tilemap.CellToWorld(new Vector3Int(xCentro, Mathf.RoundToInt(yPos), 0)) + Vector3.up * 0.5f;
                Instantiate(enemigoPrefab, enemigoWorldPos, Quaternion.identity);
            }

            // Colocar obst�culo con una probabilidad (en una posici�n aleatoria dentro de la plataforma)
            if (Random.value < probabilidadObstaculo)
            {
                int obstaculoX = Random.Range(-anchuraPlataforma / 2, anchuraPlataforma / 2 + 1);
                Vector3Int obstaculoPos = new Vector3Int(xCentro + obstaculoX, Mathf.RoundToInt(yPos), 0);
                tilemap.SetTile(obstaculoPos, obstaculoTile);
            }

            // Reducir altura para la siguiente plataforma
            yPos -= Random.Range(frecuenciaPlataformas, alturaMaximaPlataforma);
        }

        // Generar paredes a lo largo de los bordes del nivel
        for (int y = Mathf.RoundToInt(inicioAltura); y > Mathf.RoundToInt(finAltura); y--)
        {
            Vector3Int paredIzquierda = new Vector3Int(-anchoNivel / 2 - 1, y, 0);
            Vector3Int paredDerecha = new Vector3Int(anchoNivel / 2 + 1, y, 0);

            tilemap.SetTile(paredIzquierda, paredTile);
            tilemap.SetTile(paredDerecha, paredTile);
        }
    }
}
