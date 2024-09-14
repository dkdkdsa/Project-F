using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoSingleton<Inventory>
{
    [SerializeField]
    private InventoryUI _inventoryUI;

    private List<Item> _itemList = new();
    public List<Item> Items => _itemList;

    public void AddItem(Item item, int amount)
    {
        if (_itemList.Contains(item))
        {
            item.AddItemAmount(amount);
        }
        else
        {
            _itemList.Add(item);
            
            _inventoryUI.AddSlot(item);
            item.AddItemAmount(amount);
        }
    }
}
