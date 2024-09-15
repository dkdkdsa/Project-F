using System;
using UnityEngine;

public class ObjectHit : MonoBehaviour, IHitable
{

    public event Action<object> OnHitEvent;


    public void Hit(object hitData = null)
    {

        OnHitEvent?.Invoke(hitData);

    }

}
