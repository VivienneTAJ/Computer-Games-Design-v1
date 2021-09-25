using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform itemsParent;
    EquipmentManager equipmentManager;
    EquipSlot[] slots;
    Equipment newEquipment;

    void Start()
    {
        equipmentManager = EquipmentManager.instance;
        //equipmentManager.onEquipmentChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<EquipSlot>();
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].AddItem((int)newEquipment.equipmentSlot);
        }
    }
}
