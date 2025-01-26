using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject EndMenu;
    public AudioManager audioManager;

    public void Awake()
    {
        EndMenu = GameObject.Find("EndGameMenu");
        EndMenu.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("Sonido").GetComponent<AudioManager>();
        audioManager.PlaySFX(audioManager.BGM);

    }


    public void OpenEndMenu()
    { EndMenu.SetActive(true);
        Time.timeScale = 0f;
        audioManager.PlaySFX(audioManager.BGM);
       
    }

    public void CloseEndMenu() 
    { EndMenu.SetActive(false); 
        Time.timeScale = 1f;
    }

    public void ChangeMainScene()
    {
        SceneManager.LoadScene("NivelPrueba");
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
