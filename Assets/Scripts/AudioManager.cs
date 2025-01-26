using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music Clips")]
    public AudioClip menuMusic;
    public AudioClip mainSceneMusic;

    [Header("Sound Effects")]
    public AudioClip playerDeathSound;
    public AudioClip keyPressSound;
    public AudioClip platformFallSound;
    public AudioClip laWeaSpawnSound;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.loop = false;
    }

    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "Menu":
                musicSource.clip = menuMusic;
                break;
            case "MainScene":
                musicSource.clip = mainSceneMusic;
                break;
            default:
                Debug.LogWarning("Music name not recognized: " + musicName);
                return;
        }
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(string sfxName)
    {
        switch (sfxName)
        {
            case "PlayerDeath":
                sfxSource.PlayOneShot(playerDeathSound);
                break;
            case "KeyPress":
                sfxSource.PlayOneShot(keyPressSound);
                break;
            case "PlatformFall":
                sfxSource.PlayOneShot(platformFallSound);
                break;
            case "laWeaSpawn":
                sfxSource.PlayOneShot(laWeaSpawnSound);
                break;
            default:
                Debug.LogWarning("SFX name not recognized: " + sfxName);
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            AudioManager.Instance.PlayMusic("Menu");
        }
        else if (scene.name == "NivelPrueba")
        {
            AudioManager.Instance.PlayMusic("MainScene");
        }
    }

}