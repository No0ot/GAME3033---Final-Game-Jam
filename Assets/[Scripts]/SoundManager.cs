using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip menuSong;
    public AudioClip gameSong;

    public AudioSource musicSource;
    public AudioSource SFXSource;
    private void Awake()
    {
        instance = this;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayMusic(menuSong);
        }
        else
            PlayMusic(gameSong);

    }

   public void PlaySound(int sound)
    {
        switch(sound)
        {
            case 0:
                SFXSource.clip = jump1;
                SFXSource.Play();
                break;
            case 1:
                SFXSource.clip = jump2;
                SFXSource.Play();
                break;
        }
    }

    public void PlayMusic(AudioClip track)
    {
        musicSource.clip = track;
        musicSource.Play();
    }
}
