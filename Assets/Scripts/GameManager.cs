using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public GameObject fadePanel;
    public GameObject fadePanelContent;
    //public Animator anim;
    public GameObject soundManager;
    public BoolVariable won;

    private AudioSource[] audioSources;
    private int countMusicBox;
    private int countMusicBoxToWin = 6;
    private Animator anim;


    void Start()
    {
        audioSources = soundManager.GetComponentsInChildren<AudioSource>();
        anim = fadePanel.GetComponent<Animator>();
        won.value = false;
    }

    void Update()
    {
        if (!won.value)
        {
            countMusicBox = 0;
            foreach (AudioSource audioSource in audioSources)
            {
                if (audioSource.volume == 1)
                    countMusicBox++;
            }
            if (countMusicBox >= countMusicBoxToWin)
            {
                won.value = true;
                Win();
            }
        }
    }

    private void Win()
    {
        StartCoroutine(DisplayWonPanel());
    }

    private IEnumerator DisplayWonPanel()
    {
        anim.SetTrigger("Won");
        yield return new WaitForSeconds(5.0f);
        fadePanelContent.SetActive(true);
    }



    public void InitiateRemoveWonPanel()
    {
        StartCoroutine(RemoveWonPanel());
    }

    private IEnumerator RemoveWonPanel()
    {
        fadePanelContent.SetActive(false);
        anim.SetTrigger("NextLevel");
        yield return new WaitForSeconds(5.0f);
    }
}
