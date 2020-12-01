using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float delayInSeconds = 1f;
    [SerializeField] private GameObject transitionStyle;
    [SerializeField] private Button[] levelButtons;
    

    
   
    // --------------------- Methods --------------------

    private void Start()
    {
        transitionStyle.SetActive(false);
        CheckLevelUnlocked();
    }

    private void CheckLevelUnlocked()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    

    public void LoadSceneByName(string nameofSceneToLoad)
    {
        StartCoroutine(SceneNameCor(nameofSceneToLoad));
        var gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.ResetGame();
        }
    }
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevelCor(SceneManager.GetActiveScene().buildIndex + 1));
        var gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.ResetGame();
        }
    }
    
    public void RestartLastLevel()
    {
        
        StartCoroutine(LoadLevelCor(SceneManager.GetActiveScene().buildIndex));
        var gameSession = FindObjectOfType<GameSession>();
         if (gameSession != null)
         {
              gameSession.ResetGame();
        }
    }
    
    
    // ----------------------- Coroutines ----------------------
    
    IEnumerator LoadLevelCor(int levelIndex)
    {
        transitionStyle.SetActive(true);
        yield return new WaitForSecondsRealtime(delayInSeconds);
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator SceneNameCor(string nameofSceneToLoad)
    {
        transitionStyle.SetActive(true);
        yield return new WaitForSecondsRealtime(delayInSeconds);
        SceneManager.LoadScene(nameofSceneToLoad);
    }
    
}