using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private ItemSlot _slot; // itemSlot prefab
    [SerializeField] private int _maxSlotCount;

    private Transform _cloneTrm;

    private List<ItemSlot> _slotList = new();

    public ItemSlot Slot => _slot;

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

    public void AddSlot(Item item)
    {
        var newSlot = _slotList.First();
        newSlot.SetSlot(item);

        _slotList.Remove(newSlot);
    }


    #region Editor
    // 에디터에서만 실행되는 슬롯 생성 함수
    public void CreateSlots()
    {
        if (_slotList.Count > 0)
        {
            foreach (var slot in _slotList)
            {
                if (slot != null)
                {
                    DestroyImmediate(slot.gameObject); // 에디터에서 즉시 삭제
                }
            }
            _slotList.Clear();
        }

        for (int i = 0; i < _maxSlotCount; i++)
        {
            var slot = Instantiate(_slot, _cloneTrm);
            _slotList.Add(slot);
        }
    }

    // 슬롯 리스트를 초기화하는 함수
    public void ClearSlots()
    {
        foreach (var slot in _slotList)
        {
            if (slot != null)
            {
                DestroyImmediate(slot.gameObject); // 에디터에서 즉시 삭제
            }
        }
        _slotList.Clear();
        _maxSlotCount = 0;
    }
    #endregion
}