using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCollider : MonoBehaviour
{
    public BoxCollider playerCollider;
    public bool takeDamage = false;
    public PlayerHealth health;
    public int attackValue = -1; //EXAMPLE ATTACK DAMAGE

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            takeDamage = true;
            health.TakeDamage(attackValue);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == playerCollider)
        {
            takeDamage = false;         
        }
    }
}
