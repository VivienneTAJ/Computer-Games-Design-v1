using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    public static Vector3 currentPos, targetPos;

    private readonly float timeToMove = 0.2f;
    private bool isMoving;

    public FamiliarGridMovement familiarGridMovement;
    public static Directions previousDirection;

    public float rayLength = 1.4f;

    void Awake()
    {
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);
        previousDirection = Directions.Left; //Change based on where the familiar is spawned in relation to the player
    }
    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") > 0) && !isMoving)
            {
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 1);
                if (!Physics.Raycast(transform.position, Vector3.forward, rayLength))
                {
                    StartCoroutine(MovePlayer(Vector3.forward));
                    StartCoroutine(familiarGridMovement.MoveFamiliar(Vector3.forward));
                    previousDirection = Directions.Up;
                }
            }
            if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") < 0) && !isMoving)
            {
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", -1);
                if (!Physics.Raycast(transform.position, Vector3.back, rayLength))
                {
                    StartCoroutine(MovePlayer(Vector3.back));
                    StartCoroutine(familiarGridMovement.MoveFamiliar(Vector3.back));
                    previousDirection = Directions.Down;
                }
            }
            if ((Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") == 0) && !isMoving)
            {
                animator.SetFloat("Horizontal", -1);
                animator.SetFloat("Vertical", 0);
                if (!Physics.Raycast(transform.position, Vector3.left, rayLength))
                {
                    StartCoroutine(MovePlayer(Vector3.left));
                    StartCoroutine(familiarGridMovement.MoveFamiliar(Vector3.left));
                    previousDirection = Directions.Left;
                }

            }
            if ((Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") == 0) && !isMoving)
            {
                animator.SetFloat("Horizontal", 1);
                animator.SetFloat("Vertical", 0);
                if (!Physics.Raycast(transform.position, Vector3.right, rayLength))
                {
                    StartCoroutine(MovePlayer(Vector3.right));
                    StartCoroutine(familiarGridMovement.MoveFamiliar(Vector3.right));
                    previousDirection = Directions.Right;
                }
            }
            animator.SetBool("IsMoving", isMoving);
            familiarGridMovement.animator.SetBool("IsMoving", isMoving);
        }
    }
    private IEnumerator MovePlayer(Vector3 direction)
    {
        currentPos = transform.position;
        targetPos = currentPos + direction.normalized;
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
