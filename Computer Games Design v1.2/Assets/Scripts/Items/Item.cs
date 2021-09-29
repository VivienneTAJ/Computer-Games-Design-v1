using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //Use the item
        Debug.Log("Using " + name);

        switch (name)
        {
            case "Health Potion": HealthPotion(); break;
        }
        //ADD WHATEVER THE ITEM DOES HERE

        Inventory.instance.Remove(this);
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    public void HealthPotion()
    {
        PlayerHealth health = Player.instance.GetComponent<PlayerHealth>();
        health.TakeDamage(health.healthPerHeart);
    }
}
