using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public Transform StartPosition;
    private float scoreActual;

    void Start()
    {
        scoreActual = 0;
    }

    private void FixedUpdate()
    {
        scoreActual = Vector2.Distance(StartPosition.position, transform.position);
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
