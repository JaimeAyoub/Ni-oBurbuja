using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public int actualScore;
    public TMPro.TextMeshProUGUI highScoreText;
    public PlayerScore playerScore;
    public GameObject[] cuadrantes;
    public Transform[] spawns;
    public GameObject wea;
    public static ScoreManager instanceScoreManager;
    private int highScore;
    

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        WeaAttack();
    }

    private void Update()
    {
        
    }

    public void SetHighestScore()
    {
        actualScore = playerScore.GetScore();
        if (actualScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", actualScore);
            highScoreText.text = actualScore.ToString();
            highScore = actualScore;
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public int GetActualScore()
    {
        return actualScore;
    }

    void WeaAttack()
    {
        StartCoroutine(FadeCuadrantes(Random.Range(0, 3)));
    }

    IEnumerator FadeCuadrantes(int random)
    {
        #region CUADRANTES
        //if (cuadrantes.Length > random)
        //{
        //    SpriteRenderer spriteRenderer = cuadrantes[random].GetComponent<SpriteRenderer>();
        //    Color initialColor = spriteRenderer.color;
        //    spriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);
        //    spriteRenderer.DOFade(0f, 1f).SetLoops(5, LoopType.Yoyo);
        //}
        #endregion
        yield return new WaitForSeconds(4f);
        Instantiate(wea, spawns[random].position, Quaternion.identity);
    }
}
