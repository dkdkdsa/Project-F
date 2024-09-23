using FSM.Hash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/TEst")]
public class TestObject : ScriptableObject
{

    [SerializeField] private HashFSMRouteMap _map;

}
