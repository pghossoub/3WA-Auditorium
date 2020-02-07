using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public Level[] levels;
    public IntVariable currentLevel;

    //private static Loader instance = null;
    void Awake()
    {
        /*
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        */

        currentLevel.value = 1;
        LoadLevel();
    }


    public void NextLevel()
    {
        currentLevel.value += 1;
        UnloadPreviousLevel();
        //if(currentLevel.value < levels.Length + 1)
        LoadLevel();
    }

    public void LoadLevel()
    {
        //Debug.Log(string.Format("Level{0:0}", currentLevel));
        Debug.Log(levels[currentLevel.value - 1].levelName);

        //levelName = string.Format("Level{0:0}", currentLevel.value);
        SceneManager.LoadScene(levels[currentLevel.value - 1].levelName, LoadSceneMode.Additive);
    }

    public void UnloadPreviousLevel()
    {
        string previousLevelName = string.Format("Level{0:0}", currentLevel.value - 1);
        SceneManager.UnloadSceneAsync(previousLevelName);
    }
}
