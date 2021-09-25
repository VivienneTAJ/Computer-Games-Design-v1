using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {               
            Destroy(gameObject);
        }

        //for (int i = 0; i < inventory.inventorySlots.Length; i++)
        //{
        //    if (inventory.isFull[i] == false)
        //    {
        //        //item can be added to inventory
        //        inventory.isFull[i] = true;
        //        Instantiate(itemButtonIcon, inventory.inventorySlots[i].transform, false);
        //        Destroy(gameObject);

        //        break;
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other == playerCollider)
        {
            PickUp();
        }
    }
}
