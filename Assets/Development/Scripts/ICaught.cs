using System;
using UnityEngine;

public interface ICaught 
{
    public void OnCaught(Action onDeathCallback);
    public Rigidbody GetRigidbody();
}
