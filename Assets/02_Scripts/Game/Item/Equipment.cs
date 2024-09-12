using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item/Equipment", fileName = "Equipment_")]
public class Equipment : Item
{
    [Header("Equipment Info")]
    [SerializeField] private EquipmentCondition[] _conditions;
}
