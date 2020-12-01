using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
   private GameSession myGameSession;
   private LeanStars _leanStars;
   private bool hasEnteredCollision;
   public bool playerWin;
   public bool playerLose;
   private Camera _camera;


   private void Start()
   {
      myGameSession = FindObjectOfType<GameSession>();
      _leanStars = FindObjectOfType<LeanStars>();
      playerWin = false;
      playerLose = false;
      _camera = FindObjectOfType<Camera>();
   }

   private void LateUpdate()
   {
      PlayerLost();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Obstacle") && !hasEnteredCollision)
      {
        HandleStarScore();
        hasEnteredCollision = true;
        Debug.Log(myGameSession.currentNumberOfStars);
        CameraShake.Shake(0.05f, 0.5f);
        Handheld.Vibrate();
      }

      if (other.gameObject.CompareTag("WinTrigger"))
      {
         playerWin = true;
         myGameSession.PlayerWin();
         _leanStars.LeanTweenStars();
         Debug.Log("playerwin");
      }
      
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Obstacle") && hasEnteredCollision)
      {
         
         hasEnteredCollision = false;
         
      }
   }

   private void HandleStarScore()
   {
      myGameSession.DecreaseStars();
   }

   public void PlayerLost()
   {
      if (myGameSession.currentNumberOfStars < 1)
      {
         if (myGameSession != null)
         {
            playerLose = true;
            myGameSession.PlayerLose();
            _leanStars.LeanTweenStars();
            
         }
         
      }
   }
   
}
