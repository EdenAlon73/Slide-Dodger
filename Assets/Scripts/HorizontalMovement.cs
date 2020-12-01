using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
   //movement speed in units per second
       [SerializeField] private float movementSpeed = 5f;

       void Update()
       {
           //get the Input from Horizontal axis
           float horizontalInput = Input.GetAxis("Horizontal");
           
           //update the position
           transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime,
               0, 0);
       }
}
