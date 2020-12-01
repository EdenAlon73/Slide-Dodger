using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantlyMovingUp : MonoBehaviour
{
    [SerializeField] private float upMoveSpeed = 1f;
    [SerializeField] private float zValue = 1;
    private bool isMoving;
    private Player theLaser;

    private void Start()
    {
        theLaser = FindObjectOfType<Player>();
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpMovement();
        
    }

    private void UpMovement()
    {
        if (isMoving)
        {
            transform.position = transform.position + new Vector3(0, 0, zValue * upMoveSpeed * Time.deltaTime); 
        }
        if (theLaser.playerLose || theLaser.playerWin)
        {
            transform.localPosition += Vector3.right * 5000;
            isMoving = false;
        }
        
    }
    
}
