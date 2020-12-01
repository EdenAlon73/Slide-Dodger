using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    [SerializeField] private bool doIRotate = false;
    [SerializeField] private bool rotationDirectionLeft = false;
    [SerializeField] private float rotateSpeed = 1f;
    
    

    void Update()
    {
        if (doIRotate == true && rotationDirectionLeft == true)
        {
            transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));
        }
        if (doIRotate == true && rotationDirectionLeft == false)
        {
            transform.Rotate(-Vector3.up * (rotateSpeed * Time.deltaTime));
        }
    }
}
