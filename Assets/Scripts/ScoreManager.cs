using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public int actualScore;
    public TMPro.TextMeshProUGUI highScoreText;
    public PlayerScore playerScore;
    public GameObject[] cuadrantes;

    void Start()
    {
        //highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        WeaAttack();
    }

    public void SetHighestScore()
    {
        actualScore = playerScore.GetScore();
        if (actualScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", actualScore);
            highScoreText.text = actualScore.ToString();
        }
    }

    void WeaAttack()
    {
        StartCoroutine(FadeCuadrantes(Random.Range(0, cuadrantes.Length)));
    }

    IEnumerator FadeCuadrantes(int random)
    {
        if (cuadrantes.Length > random)
        {
            SpriteRenderer spriteRenderer = cuadrantes[random].GetComponent<SpriteRenderer>();
            Color initialColor = spriteRenderer.color;
            spriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);
            spriteRenderer.DOFade(0f, 1f).SetLoops(5, LoopType.Yoyo);  
        }
        yield return new WaitForSeconds(4f);  
    }

}
