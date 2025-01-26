using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioClip mainTheme;

    public int music_delay_time = 1;

    private void Start()
    {
        PlayMusic(mainTheme);
    }

    public void PlayInstaMusic(AudioClip music_clip)
    {
        musicSource.clip = music_clip;
        musicSource.Play();
        Debug.Log("Now playing insta: " + music_clip.name);
    }

    public void PlayMusic(AudioClip music_clip)
    {
        musicSource.clip = music_clip;
        musicSource.PlayDelayed(music_delay_time);
        Debug.Log("Now playing delayed: " + music_clip.name);
    }
    public void PauseMusic(AudioClip music_clip)
    {
        if (musicSource.clip == music_clip && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void PlaySFX(AudioClip sfx_clip)
    {
        if (!sfxSource.isPlaying)
        {
            sfxSource.PlayOneShot(sfx_clip);
        }
    }
}
