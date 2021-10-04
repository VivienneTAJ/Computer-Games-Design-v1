using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform itemsParent;
    public EquipmentManager equipmentManager;
    public EquipSlot[] slots;
    public static Equipment newEquipment;
    public static int slotIndex;
    public static bool addItem = false;

    void Start()
    {        
        equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipmentChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<EquipSlot>();
    }
    void UpdateUI()
    {
        if (addItem)
        {
            newEquipment = equipmentManager.currentEquipment[slotIndex];
            slots[slotIndex].AddItem(slotIndex);
            addItem = false;
        }
    }
}
