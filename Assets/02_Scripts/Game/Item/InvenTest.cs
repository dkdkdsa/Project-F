using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenTest : MonoBehaviour
{
    [SerializeField] private Item _item;

    private Item newItem;

    private void Awake() {
         newItem = _item.Clone().Cast<Item>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.G))
        {
            newItem.Quantity++;
            Inventory.Instance.AddItem(newItem);
        }
    }
}
