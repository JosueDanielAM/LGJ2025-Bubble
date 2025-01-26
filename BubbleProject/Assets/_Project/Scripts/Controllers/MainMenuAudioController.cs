using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioController : MonoBehaviour
{
    [SerializeField] AudioSource music_source;
    [SerializeField] AudioClip main_menu_theme;

    private void Start()
    {
        music_source.clip = main_menu_theme;
        music_source.Play();
    }
}
