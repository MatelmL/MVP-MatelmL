using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableEvent : MonoBehaviour
{
   public UnityEvent onEnable;
   public bool skipFirst = true;
   
   private void OnEnable()
   {
      if (skipFirst)
      {
         skipFirst = false;
         return;
      }
      onEnable.Invoke();
   }
}
