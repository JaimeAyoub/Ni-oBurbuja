using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

<<<<<<< Updated upstream
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    
    private void Awake()
=======
    public TMPro.TextMeshProUGUI actualEndScore;
    public TMPro.TextMeshProUGUI highEndScore;
    public ScoreManager playerScore;


    public void Awake()
>>>>>>> Stashed changes
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

<<<<<<< Updated upstream
    private void ChangeMainScene()
=======
    public void OpenEndMenu()
    { 
        EndMenu.SetActive(true);
        Time.timeScale = 0f;
        actualEndScore.text = playerScore.GetActualScore().ToString();
        highEndScore.text = playerScore.GetHighScore().ToString();
    }

    public void CloseEndMenu() 
    { EndMenu.SetActive(false); 
        Time.timeScale = 1f;
    }

    public void ChangeMainScene()
>>>>>>> Stashed changes
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    private void ChangeMenuScene()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    private void QuitApplication()
    {
        Application.Quit();
    }


}
