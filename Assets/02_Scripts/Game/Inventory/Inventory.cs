using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemSlot _slot;
    [SerializeField] private int _slotCount;

    private Transform _cloneTrm;

    private List<ItemSlot> _itemSlots = new List<ItemSlot>();

    private void Awake() 
    {
        _cloneTrm = transform.GetChild(0).transform;

        for (int i = 0; i < _slotCount; i++)
        {
            var slot = _slot.Clone().Cast<ItemSlot>();
            slot.transform.SetParent(_cloneTrm);
            _itemSlots.Add(slot);
        }  
    }

    public void SetInventory()
    {

    }
}
