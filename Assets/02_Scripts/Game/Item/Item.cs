using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Item : ScriptableObject, ICloneable
{
    public delegate void UpdateHandler(Item item);

    [Header("Item Info")]
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _itemIcon;

    public string ItemName => _itemName;
    public Sprite ItemIcon => _itemIcon;
    public int Quantity; // 임시

    public event UpdateHandler OnUpdate;

    public object Clone()
    {
        var obj = Instantiate(this);
        return obj;
    }

    public void Update()
    {
        OnUpdate(this);
    }

    public void UnRegister()
    {
        OnUpdate = null;
    }
}
