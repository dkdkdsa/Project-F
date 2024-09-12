using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject, ICloneable
{
    [Header("Item Info")]
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _itemIcon;

    public string ItemName => _itemName;
    public Sprite ItemIcon => _itemIcon;

    public int Quantity { get; set; } // 임시

    public object Clone()
    {
        var obj = Instantiate(this);
        return obj;
    }
}
