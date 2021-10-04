using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Equipment slots found!");
            return;
        }
        instance = this;
    }
    #endregion

    public Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(/*Equipment newItem, Equipment oldItem*/);
    public OnEquipmentChanged onEquipmentChangedCallback;
    Inventory inventory;
    private void Start()
    {
        inventory = Inventory.instance;
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];

    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.U))
    //    {
    //        UnequipAll();
    //    }

    //    // set equipslot[0] item = currentEquipment[0]
    //    // set equipslot[1] item = currentEquipment[1]
    //}


    public void Equip(Equipment newEquipment)
    {
        int slotIndex = (int)newEquipment.equipmentSlot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);          
        }

        currentEquipment[slotIndex] = newEquipment;

        //WORKS UP TO HERE!!

        if (onEquipmentChangedCallback != null)
        {
            EquipmentUI.newEquipment = newEquipment;
            EquipmentUI.slotIndex = slotIndex;
            EquipmentUI.addItem = true;
            onEquipmentChangedCallback.Invoke();
        }
        
        //icon.sprite = null;
        //icon.enabled = false;
        //removeButton.interactable = false;
    }
    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChangedCallback != null)
            {
                onEquipmentChangedCallback.Invoke();
            }       
        }
    }
    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
}
