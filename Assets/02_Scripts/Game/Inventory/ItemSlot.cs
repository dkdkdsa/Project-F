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

    public object Clone()
    {
        var clone = Instantiate(this);

        clone.slotIcon = clone.transform.Find("Icon").GetComponent<Image>();
        clone.slotQuantityText = clone.transform.Find("Quantity").GetComponent<TextMeshProUGUI>();

        return clone;
    }

    public void SetSlot(Item item)
    {
        item.OnValueUpdate += UpdateSlot;
        item.OnRemove += RemoveSlot;

        UpdateSlot(item);
    }

    public void UpdateSlot(Item item)
    {
        slotIcon.sprite = item.ItemIcon;
        slotQuantityText.text = $"{item.Quantity}";
    }

    public void RemoveSlot()
    {
        slotIcon.sprite = null;
        slotQuantityText.text = String.Empty;
    }
}
