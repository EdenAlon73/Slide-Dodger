using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [Header("Game Session Config")]
    [SerializeField] private int starsToDecrease = 1;
    [SerializeField] public int currentNumberOfStars = 5;
    [SerializeField] private GameObject youWinCanvas;
    [SerializeField] private GameObject youLoseCanvas;
    [SerializeField] private float delayInSeconds = 2;
    public Player thePlayerAkaLaser;
    

    private void Awake()
    {
        SetUpSingleton();
        currentNumberOfStars = 5;
        youWinCanvas.SetActive(false);
        youLoseCanvas.SetActive(false);
        thePlayerAkaLaser = FindObjectOfType<Player>();
    }
    
    private void SetUpSingleton()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;
        
        if (numberGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);   
        }
    }
    
    public void DecreaseStars()
    {
        currentNumberOfStars = currentNumberOfStars - starsToDecrease;
    }

    public int GetScore()
    {
        return currentNumberOfStars;
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void PlayerWin()
    {
        if (thePlayerAkaLaser.playerWin)
        {
            PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex + 1);
            StartCoroutine(LoadYouWinCanvas());
            
        }
        
    }

    public void PlayerLose()
    {
         if (thePlayerAkaLaser.playerLose)
         {
             StartCoroutine(LoadYouLoseCanvas());
             
         }
    }
    

    IEnumerator LoadYouWinCanvas()
    {
        youWinCanvas.SetActive(true);
        yield return new WaitForSecondsRealtime(delayInSeconds);
        
    }
    IEnumerator LoadYouLoseCanvas()
    {
        youLoseCanvas.SetActive(true);
        yield return new WaitForSecondsRealtime(delayInSeconds);
        
    }
}
