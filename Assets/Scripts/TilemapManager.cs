using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Tilemap platformTilemap; // Tilemap para las plataformas
    public Tile platformTile; // Tile para representar las plataformas
    public Tile barrierTile; // Tile para representar las barreras
    public GameObject[] enemyPrefabs; // Prefabs de los enemigos

    public int initialPlatforms = 10; // Cantidad de plataformas iniciales
    public float platformSpacing = 3f; // Distancia entre plataformas
    public float platformWidth = 2f; // Ancho virtual de las plataformas

    private Transform player;
    private float lastSpawnedY;
    private float screenBottomY;
    private BoundsInt leftBarrierBounds;
    private BoundsInt rightBarrierBounds;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        // Obtener la posición inferior de la pantalla
        screenBottomY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        // Generar plataformas iniciales
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform(-i * platformSpacing);
        }

        lastSpawnedY = -initialPlatforms * platformSpacing;

        // Crear barreras laterales
        CreateBarriers();
    }

    void Update()
    {
        // Generar nuevas plataformas cuando el jugador se acerca al final
        while (lastSpawnedY > player.position.y - (platformSpacing * initialPlatforms))
        {
            SpawnPlatform(lastSpawnedY - platformSpacing);
            lastSpawnedY -= platformSpacing;
        }

        // Actualizar las barreras laterales para seguir al jugador
        UpdateBarriers();
    }

    void SpawnPlatform(float yPosition)
    {
        // Calcular una posición aleatoria dentro del ancho permitido
        float xPosition = Random.Range(-platformWidth / 2f, platformWidth / 2f);

        // Convertir las coordenadas del mundo a celdas del Tilemap
        Vector3Int tilePosition = platformTilemap.WorldToCell(new Vector3(xPosition, yPosition, 0));

        // Colocar el tile en el Tilemap
        platformTilemap.SetTile(tilePosition, platformTile);

        // Generar un enemigo encima de la plataforma
        SpawnEnemyAbovePlatform(tilePosition);
    }

    void SpawnEnemyAbovePlatform(Vector3Int tilePosition)
    {
        if (enemyPrefabs.Length > 0)
        {
            // Obtener una posición mundial para el enemigo, ligeramente por encima del tile
            Vector3 spawnPosition = platformTilemap.CellToWorld(tilePosition) + new Vector3(0.5f, 1f, 0);
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void CreateBarriers()
    {
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;

        // Definir los límites de las barreras izquierda y derecha
        leftBarrierBounds = new BoundsInt(
            platformTilemap.WorldToCell(new Vector3(-cameraWidth - 0.5f, player.position.y - 10f, 0)),
            new Vector3Int(1, 20, 1)
        );

        rightBarrierBounds = new BoundsInt(
            platformTilemap.WorldToCell(new Vector3(cameraWidth + 0.5f, player.position.y - 10f, 0)),
            new Vector3Int(1, 20, 1)
        );

        // Colocar los tiles iniciales de las barreras
        for (int y = leftBarrierBounds.yMin; y < leftBarrierBounds.yMax; y++)
        {
            platformTilemap.SetTile(new Vector3Int(leftBarrierBounds.xMin, y, 0), barrierTile);
            platformTilemap.SetTile(new Vector3Int(rightBarrierBounds.xMin, y, 0), barrierTile);
        }
    }

    void UpdateBarriers()
    {
        // Actualizar las posiciones verticales de las barreras según el jugador
        leftBarrierBounds.position = platformTilemap.WorldToCell(new Vector3(leftBarrierBounds.position.x, player.position.y - 10f, 0));
        rightBarrierBounds.position = platformTilemap.WorldToCell(new Vector3(rightBarrierBounds.position.x, player.position.y - 10f, 0));

        // Actualizar los tiles de las barreras
        for (int y = leftBarrierBounds.yMin; y < leftBarrierBounds.yMax; y++)
        {
            platformTilemap.SetTile(new Vector3Int(leftBarrierBounds.xMin, y, 0), barrierTile);
            platformTilemap.SetTile(new Vector3Int(rightBarrierBounds.xMin, y, 0), barrierTile);
        }
    }
}
