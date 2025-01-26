using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoldManager : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab de las plataformas
    public GameObject barrierPrefab; // Prefab de las barreras
    public GameObject[] enemyPrefabs; // Prefabs de los enemigos
    public float platformWidth = 2f; // Ancho de las plataformas
    public float platformSpacing = 3f; // Distancia entre plataformas
    public int initialPlatforms = 10; // Cantidad de plataformas iniciales
    public int poolSize = 20; // Tamaño del pool de objetos

    private Transform player;
    private float lastSpawnedY;
    private float screenBottomY;
    private GameObject leftBarrier;
    private GameObject rightBarrier;
    private Queue<GameObject> platformPool;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        // Obtener la posición inferior de la pantalla
        screenBottomY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        // Crear el pool de plataformas
        platformPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject platform = Instantiate(platformPrefab);
            platform.SetActive(false);
            PlatformOffScreenHandler handler = platform.AddComponent<PlatformOffScreenHandler>();
            handler.gameManager = this; // Asignar gameManager correctamente
            platformPool.Enqueue(platform);
        }

        // Generar las plataformas iniciales
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

        // Asegurar que las barreras sigan al jugador
        UpdateBarriers();
    }

    void SpawnPlatform(float yPosition)
    {
        if (platformPool.Count > 0)
        {
            GameObject platform = platformPool.Dequeue();
            float xPosition = Random.Range(-platformWidth / 2f, platformWidth / 2f);
            platform.transform.position = new Vector3(xPosition, yPosition, 0);
            platform.SetActive(true);

            // Generar enemigos encima de la plataforma
            SpawnEnemyAbovePlatform(platform);
        }
    }

    void SpawnEnemyAbovePlatform(GameObject platform)
    {
        if (enemyPrefabs.Length > 0)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Vector3 spawnPosition = platform.transform.position + new Vector3(0, 1f, 0); // Posición sobre la plataforma
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void ReturnPlatformToPool(GameObject platform)
    {
        platform.SetActive(false);
        platformPool.Enqueue(platform);
    }

    void CreateBarriers()
    {
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;

        // Crear la barrera izquierda
        leftBarrier = Instantiate(barrierPrefab);
        leftBarrier.transform.position = new Vector3(-cameraWidth - 0.5f, player.position.y, 0);
        leftBarrier.transform.localScale = new Vector3(1, 20, 1);

        // Crear la barrera derecha
        rightBarrier = Instantiate(barrierPrefab);
        rightBarrier.transform.position = new Vector3(cameraWidth + 0.5f, player.position.y, 0);
        rightBarrier.transform.localScale = new Vector3(1, 20, 1);
    }

    void UpdateBarriers()
    {
        leftBarrier.transform.position = new Vector3(leftBarrier.transform.position.x, player.position.y, 0);
        rightBarrier.transform.position = new Vector3(rightBarrier.transform.position.x, player.position.y, 0);
    }
}
