using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour

{
    private AudioSource[] audioSources;
    private int countMusicBox;
    private int countMusicBoxToWin = 6;

    void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
    }

    void Update()
    {
        countMusicBox = 0;
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.volume == 1)
                countMusicBox++;
        }
        if (countMusicBox >= countMusicBoxToWin)
            //Win!
            Debug.Log("Win!");

    }
}
