using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStars : MonoBehaviour
{
    public int maxStars;
    public int currentStars;
    public Image[] starImgs;
    public Sprite fullStar;
    public Sprite emptyStar;
    private GameSession myGameSession;


    private void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        maxStars = currentStars;
        
    }

    private void Update()
    {
        currentStars = myGameSession.GetScore();
        
        if (maxStars > currentStars)
        {

            for (int i = 0; i < maxStars; i++)
            {
                if (i < maxStars)
                {
                    starImgs[i].sprite = fullStar;
                }
                else
                {
                    starImgs[i].sprite = emptyStar;
                }
                

                if (i < currentStars)
                {
                    starImgs[i].enabled = true;
                }
                else
                {
                    starImgs[i].enabled = false;
                }
                
                
            }
        }
        
    }
}
