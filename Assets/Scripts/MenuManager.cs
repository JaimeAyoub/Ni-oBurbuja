using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject EndMenu;
    public static MenuManager InstanceMenuManager;
    public TMPro.TextMeshProUGUI endHighScore;
    public TMPro.TextMeshProUGUI endActualScore;

    public void Awake()
    {
        EndMenu = GameObject.Find("EndGameMenu");
        EndMenu.SetActive(false);
    }

    public void OpenEndMenu()
    { 
        EndMenu.SetActive(true);
        Time.timeScale = 0f;
        ScoreManager.instanceScoreManager.SetHighestScore();
        endHighScore.text = ScoreManager.instanceScoreManager.GetHighScore().ToString();
        endActualScore.text = ScoreManager.instanceScoreManager.GetActualScore().ToString();
    }

    public void CloseEndMenu() 
    { EndMenu.SetActive(false); 
        Time.timeScale = 1f;
    }

    public void ChangeMainScene()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void ChangeMenuScene()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }


}
