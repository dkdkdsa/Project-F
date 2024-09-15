using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(InventoryUI))]
public class InventoryUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InventoryUI inventoryUI = (InventoryUI)target;

        if (GUILayout.Button("설정한 개수만큼 슬롯 생성하기"))
        {
            inventoryUI.CreateSlots(); 
        }

        if (GUILayout.Button("슬롯 초기화"))
        {
            inventoryUI.ClearSlots(); 
        }
    }
}
#endif