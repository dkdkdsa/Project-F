using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoSingleton<Inventory>
{
    [SerializeField] private ItemSlot _slot; // itemSlot prefab
    [SerializeField] private int _maxSlotCount;
    
    private Transform _cloneTrm;

    private List<ItemSlot> _slotList = new();
    private List<Item> _itemList = new();

    private void Awake() 
    {
        _cloneTrm = transform.GetChild(0).transform;

        for (int i = 0; i < _maxSlotCount; i++)
        {
            var slot = _slot.Clone().Cast<ItemSlot>();
            slot.transform.SetParent(_cloneTrm);
            _slotList.Add(slot);
        }  
    }

    public void AddItem(Item item)
    {
        if (_itemList.Contains(item))
        {
            item.Update();
        }
        else
        {
            _itemList.Add(item);
            AddSlot(item);
        }
    }

    public void AddSlot(Item item)
    {
        var newSlot = _slotList.First();
        newSlot.SetSlot(item);
            
        _slotList.Remove(newSlot);
    }
}
