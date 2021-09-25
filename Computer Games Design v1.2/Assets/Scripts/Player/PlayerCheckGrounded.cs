using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckGrounded : MonoBehaviour
{
    public static bool canMoveL, canMoveR, canMoveU, canMoveD;
    public BoxCollider playerColliderL, playerColliderR, playerColliderU, playerColliderD;
    private void OnTriggerEnter(Collider other)
    {
        if (other == playerColliderL)
        {
            canMoveL = true;
        }
        if (other == playerColliderR)
        {
            canMoveR = true;
        }
        if (other == playerColliderU)
        {
            canMoveU = true;
        }
        if (other == playerColliderD)
        {
            canMoveD = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == playerColliderL)
        {
            canMoveL = false;
        }
        if (other == playerColliderR)
        {
            canMoveR = false;
        }
        if (other == playerColliderU)
        {
            canMoveU = false;
        }
        if (other == playerColliderD)
        {
            canMoveD = false;
        }
    }
}
