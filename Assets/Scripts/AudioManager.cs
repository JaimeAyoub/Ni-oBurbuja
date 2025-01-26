using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source----------")]
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXsource;
    [Header("---------Audio Clip----------")]
    public AudioClip PlatSFX;
    public AudioClip BGM;
    public AudioClip DeathSFX;
    public AudioClip WeaSFX;
    public AudioClip BGM2SFX;
    
    private void Start()
    {
       
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }

}