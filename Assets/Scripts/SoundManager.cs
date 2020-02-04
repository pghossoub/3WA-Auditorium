using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip music;

    public FloatVariable volume;

    private new AudioSource audio;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0f;
        PlayMusic();
    }

    IEnumerator LoopMusic()
    {

        yield return new WaitForSeconds(16.1f);
        audio.Stop();
        PlayMusic();

    }

    public void PlayMusic()
    {
        audio.Play();
        StartCoroutine(LoopMusic());
    }
}
