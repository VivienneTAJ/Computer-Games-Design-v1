using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : PlayerCheckGrounded
{
    //THIS NEEDS TO BE DONE COMPLETELY DIFFERENTLY. STUFF BREAKING LEFT RIGHT AND CENTRE

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other == playerColliderL)
    //    {
    //        canMoveL = true;
    //    }
    //    if (other == playerColliderR)
    //    {
    //        canMoveR = true;
    //    }
    //    if (other == playerColliderU)
    //    {
    //        canMoveU = true;
    //    }
    //    if (other == playerColliderD)
    //    {
    //        canMoveD = true;
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other == playerColliderL)
    //    {
    //        canMoveL = false;
    //    }
    //    if (other == playerColliderR)
    //    {
    //        canMoveR = false;
    //    }
    //    if (other == playerColliderU)
    //    {
    //        canMoveU = false;
    //    }
    //    if (other == playerColliderD)
    //    {
    //        canMoveD = false;
    //    }
    //}
}
