using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Item : ScriptableObject, ICloneable
{
    public delegate void ValueUpdateHandler(Item item);
    public delegate void RemoveHandler();

    [Header("Item Info")]
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _itemIcon;

    public string ItemName => _itemName;
    public Sprite ItemIcon => _itemIcon;
    public int Quantity; // 임시

    public event ValueUpdateHandler OnValueUpdate;
    public event RemoveHandler OnRemove;

    public object Clone()
    {
        var obj = Instantiate(this);
        return obj;
    }

    public void AddItem(int amount)
    {
        Quantity += amount;

        if (Quantity <= 0)
            RemoveItem();

        OnValueUpdate?.Invoke(this);
    }

    public void RemoveItem()
    {
        OnRemove?.Invoke();

        OnValueUpdate = null;
        OnRemove = null;
    }
}
