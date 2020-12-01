using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
public class NotificationPop : MonoBehaviour
{
    
    
    public NotificationManager notificationObject;
    void Start()
    {
        notificationObject.OpenNotification();
    }

  
}
