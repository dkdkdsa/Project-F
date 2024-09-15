using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTest : MonoBehaviour
{

    private void Awake()
    {

        GetComponent<IHitable>().OnHitEvent += Evt;

    }

    private void Evt(object obj)
    {

        Debug.Log(obj.Cast<AttackData>().damage);

    }
}
