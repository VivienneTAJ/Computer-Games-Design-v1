using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarGridMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    //public Rigidbody rb;
    public Animator animator;

    public static Vector3 currentPos;
    public static Vector3 targetPos;

    private readonly float timeToMove = 0.2f;
    private bool isMoving;

    void Awake()
    {
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);
    }

    public void CheckDirection(Directions directions)
    {
        switch (directions)
        {
            case Directions.Up:
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 1);
                break;
            case Directions.Down:
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", -1);
                break;
            case Directions.Left:
                animator.SetFloat("Horizontal", -1);
                animator.SetFloat("Vertical", 0);
                break;
            case Directions.Right:
                animator.SetFloat("Horizontal", 1);
                animator.SetFloat("Vertical", 0);
                break;
        }
    }
    
    public IEnumerator MoveFamiliar(Vector3 direction)
    {
        CheckDirection(PlayerGridMovement.previousDirection);

        currentPos = transform.position;
        targetPos = PlayerGridMovement.currentPos;
        isMoving = true;
        float elapsedTime = 0;
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
