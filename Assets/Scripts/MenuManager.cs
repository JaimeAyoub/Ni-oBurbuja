using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public GameObject MainMenu;
    public GameObject CreditsMenu;
    
    private void Awake()
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

    private void ChangeMainScene()
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
