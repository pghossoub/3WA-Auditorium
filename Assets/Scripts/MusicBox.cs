using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public string musicName;
    public float volumePerParticle;
    public float volumeLoss = 0.05f;
    public FloatVariable m_volume;
    public GameObject[] bars;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GameObject.FindGameObjectWithTag(musicName).GetComponent<AudioSource>();

        foreach(GameObject bar in bars)
        {
            bar.SetActive(false);
        }

        StartCoroutine(LoseVolumeOnTime());

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("EnterInMusicBox");

        if (_audioSource.volume < 1)
            _audioSource.volume += volumePerParticle;

        drawBars();

    }

    IEnumerator LoseVolumeOnTime()
    {
        while (true)
        {
            //Debug.Log("Volume Loss");
            yield return new WaitForSeconds(0.1f);
            if (_audioSource.volume > 0)
                _audioSource.volume -= volumeLoss;
            drawBars();
        }
    }

    private void drawBars()
    {
        int i = 1;
        foreach (GameObject bar in bars)
        {
            if (_audioSource.volume * 10 >= i)
                bar.SetActive(true);
            i++;
        }
    }

}
