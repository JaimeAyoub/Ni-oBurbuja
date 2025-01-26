using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuadrantes : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Start()
    {
        transform.position = new Vector2 (0, player.position.y);
    }

    void Update()
    {
        
    }
}
