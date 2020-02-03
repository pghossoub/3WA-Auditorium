using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public FloatVariable m_volume;

    private SoundManager _soundManager;

    private void Awake()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("EnterInMusicBox");
        m_volume.value = 1;
        _soundManager.PlayMusic(false);

    }
}
