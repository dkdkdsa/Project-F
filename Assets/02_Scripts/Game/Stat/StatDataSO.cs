using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatObject
{

    public string key;
    public Stat stat;

}

[CreateAssetMenu(menuName = "SO/Data/Stat")]
public class StatDataSO : ScriptableObject
{

    [field: SerializeField] public List<StatObject> Stats { get; set; }


}