using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSencer : MonoBehaviour, ISencer
{

    private bool _sencing;

    public bool CheckSencing()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        _sencing = true;
    }

}
