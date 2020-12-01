using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanStars : MonoBehaviour
{
    

    public void LeanTweenStars()
    {
        LeanTween.move(gameObject.GetComponent<RectTransform>(), new Vector3(855, -2089, 0), 0.5f);
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), new Vector3(1.5f, 1.5f, 1.5f), 0.5f);
    }
}
