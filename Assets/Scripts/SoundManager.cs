using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //public AudioSource[] musics;
    public AudioClip[] musics;

    public FloatVariable volume;

    private new AudioSource audio;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        volume.value = 0f;
        PlayMusic(true);
    }

    void Update()
    {
        
    }

    IEnumerator LoopMusic()
    {
        
        yield return new WaitForSeconds(16.1f);
        audio.Stop();
        PlayMusic(true);

    }

    public void PlayMusic(bool loop)
    {
        
        foreach (AudioClip music in musics)
        {
            
            //audio.clip = music;
            audio.PlayOneShot(music, volume.value);
        }
        if(loop)
            StartCoroutine(LoopMusic());
    }
}
