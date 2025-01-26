using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuadrantes : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject wea;
    [SerializeField] private Transform[] spawnPoint;

    void Start()
    {
        spawnPoint = new Transform[3];
    }

    void Update()
    {
        transform.position = new Vector2(0, player.position.y);
    }
}
