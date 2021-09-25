using UnityEngine;

public class Interactable : MonoBehaviour
{
    public BoxCollider playerCollider;
    public bool interactable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            interactable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == playerCollider)
        {
            interactable = false;
        }
    }
}
