using UnityEngine;
using System.Collections;
using static System.TimeZoneInfo;


public class MusicManager : MonoBehaviour
{
    
    
    public static MusicManager instance { get; private set; }
    public AudioSource backgroundMusicSource;
    private float transitionTime = 10f;
    private void Awake()
    {
        instance = this;
        backgroundMusicSource = GetComponent<AudioSource>();
    }

    public void PlayBackgroundMusic(AudioClip backgroundMusic)
    {
        backgroundMusicSource.Stop(); // Stop the current music, if any.
        backgroundMusicSource.clip = backgroundMusic;
        
        StartCoroutine(Wait(backgroundMusicSource, transitionTime));
        
    }

    public void stopMusic()
    {
        backgroundMusicSource.Stop();
    }

    private IEnumerator Wait(AudioSource nextSource, float transitionTime)
    {
        float currentTime = 0;
        yield return new WaitForSeconds(2);
        backgroundMusicSource.Play();
        while (currentTime < transitionTime)
        {
            currentTime += Time.deltaTime;

            
            nextSource.volume = 0.8f* currentTime / transitionTime;

            yield return null;
        }

        
    }


}

