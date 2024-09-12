using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, ICloneable
{
    private Image slotIcon;
    private TextMeshProUGUI slotQuantityText;

    private Sprite _itemIcon;
    private int _itemQuantity;

    public object Clone()
    {
        var clone = Instantiate(this);

        clone.slotIcon = clone.GetComponentInChildren<Image>();
        clone.slotQuantityText = clone.GetComponentInChildren<TextMeshProUGUI>();

        return clone;
    }

    public void SetSlot(Item item)
    {
        _itemIcon = item.ItemIcon;
        _itemQuantity = item.Quantity;
    }
}
