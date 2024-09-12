using System.Collections.Generic;
using UnityEngine;

public class StatContainer : MonoBehaviour, IStatContainer
{

    [SerializeField] protected StatDataSO _data;

    public Dictionary<int, Stat> Container { get; set; } = new();

    protected virtual void Awake()
    {

        foreach (var item in _data.Stats)
        {

            (this as IStatContainer).AddStat(item.key, item.stat.Clone<Stat>());

        }

    }

}
