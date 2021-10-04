using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Equipment equipment;
    public static int slotIndex;

    public void AddItem(int slotIndex)
    {
        //slotIndex = (int)newEquipment.equipmentSlot;
        //equipment = newEquipment;
        //slotIndex = EquipmentManager.currentEquipment[];

        equipment = EquipmentUI.newEquipment;
        icon.sprite = equipment.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot(int slotindex)
    {
        equipment = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        //equipment = EquipmentUI.newEquipment;
        EquipmentManager.instance.Unequip(((int)equipment.equipmentSlot));
        ClearSlot(((int)equipment.equipmentSlot));
    }
    public void UseItem()
    {
        if (equipment != null)
        {
            equipment.Use();
        }
    }
}
