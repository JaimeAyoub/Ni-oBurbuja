using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public GameObject StartPosition;
    private float scoreActual;

    private void Awake()
    {
        StartPosition = GameObject.Find("TargetDistance");
    }
    void Start()
    {
        scoreActual = 0;
    }

    private void FixedUpdate()
    {
        scoreActual = Vector2.Distance(StartPosition.transform.position, transform.position);
        scoreActual = Mathf.RoundToInt(scoreActual);
        //Debug.Log("Score = " + scoreActual.ToString());
    }

    public int GetScore()
    {
        return (int)scoreActual;
    }

    void Update()
    {
        
    }
}
