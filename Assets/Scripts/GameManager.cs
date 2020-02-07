using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager instance = null;

    public GameObject fadePanel;
    public GameObject fadePanelContent;
    public GameObject endPanel;

    public GameObject soundManager;
    public BoolVariable won;
    public IntVariable currentLevel;
    public Level[] levels;


    private AudioSource[] audioSources;
    private int countMusicBox;
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
            //Debug.Log(levels[currentLevel.value - 1].nbMusicBoxes);
            if (countMusicBox >= levels[currentLevel.value - 1].nbMusicBoxes)
            {
                won.value = true;
                Win();
            }
        }

        else
        {
            SetVolumeTo(1);
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
        if (currentLevel.value < levels.Length)
            fadePanelContent.SetActive(true);
        else
            endPanel.SetActive(true);
    }



    public void InitiateNextLevel()
    {
        StartCoroutine(RemoveWonPanel());

        won.value = false;
        SetVolumeTo(0);

        Loader loader = GameObject.FindGameObjectWithTag("Loader").GetComponent<Loader>();
        loader.NextLevel();
        
    }

    private IEnumerator RemoveWonPanel()
    {
        fadePanelContent.SetActive(false);
        anim.SetTrigger("NextLevel");
        yield return new WaitForSeconds(5.0f);
    }

    private void SetVolumeTo(float volume)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }
}
