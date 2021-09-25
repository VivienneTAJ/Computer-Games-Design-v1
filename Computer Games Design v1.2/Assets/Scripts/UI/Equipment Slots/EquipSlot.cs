using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    Equipment equipment;
    public static int slotIndex;

    public void AddItem(int slotIndex)
    {
        //slotIndex = (int)newEquipment.equipmentSlot;
        //equipment = newEquipment;

        icon.sprite = equipment.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot()
    {

       // equipment = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        EquipmentManager.instance.Unequip(((int)equipment.equipmentSlot));
    }
    public void UseItem()
    {
        if (equipment != null)
        {
            equipment.Use();
        }
    }
}
