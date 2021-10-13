using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    //public Rigidbody rb;
    public Animator animator;

    public static Vector3 currentPos;
    public static Vector3 targetPos;
    public static Quaternion playerRotation;

    private readonly float timeToMove = 0.2f;
    private bool isMoving;

    public FamiliarGridMovement familiarGridMovement;
    public static Directions previousDirection;
    void Awake()
    {
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);
        previousDirection = Directions.Left; //Change based on where the familiar is spawned in relation to the player
        playerRotation = this.transform.rotation;
    }
    void Update()
    {
        //COULD STILL BE ADJUSTED? -  Player slides along boundary edge when keys spammed
        if (!PauseMenu.gameIsPaused)
        {
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") > 0)
            {
                if (!isMoving && PlayerCheckGrounded.canMoveU && PlayerCollision.canMoveU)
                {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", 1);

                    StartCoroutine(MovePlayer(Vector3.forward));
                    StartCoroutine(familiarGridMovement.MoveFamiliar(Vector3.forward));
                    previousDirection = Directions.Up;
                }
                else if (!PlayerCheckGrounded.canMoveU || !PlayerCollision.canMoveU)
                {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", 1);
                }
            }
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") < 0)
            {
                if (!isMoving && PlayerCheckGrounded.canMoveD && PlayerCollision.canMoveD)
                {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", -1);

                    StartCoroutine(MovePlayer(Vector3.back));
                    StartCoroutine(familiarGridMovement.MoveFamiliar(Vector3.back));
                    previousDirection = Directions.Down;
                }
                else if (!PlayerCheckGrounded.canMoveD || !PlayerCollision.canMoveD)
                {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", -1);
                }
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                if (!isMoving && PlayerCheckGrounded.canMoveL && PlayerCollision.canMoveL)
                {
                    animator.SetFloat("Horizontal", -1);
                    animator.SetFloat("Vertical", 0);

                    StartCoroutine(MovePlayer(Vector3.left));
                    StartCoroutine(familiarGridMovement.MoveFamiliar(Vector3.left));
                    previousDirection = Directions.Left;
                }
                else if (!PlayerCheckGrounded.canMoveL || !PlayerCollision.canMoveL)
                {
                    animator.SetFloat("Horizontal", -1);
                    animator.SetFloat("Vertical", 0);
                }
            }
            if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                if (!isMoving && PlayerCheckGrounded.canMoveR && PlayerCollision.canMoveR)
                {
                    animator.SetFloat("Horizontal", 1);
                    animator.SetFloat("Vertical", 0);

                    StartCoroutine(MovePlayer(Vector3.right));
                    StartCoroutine(familiarGridMovement.MoveFamiliar(Vector3.right));
                    previousDirection = Directions.Right;
                }
                else if (!PlayerCheckGrounded.canMoveR || !PlayerCollision.canMoveR)
                {
                    animator.SetFloat("Horizontal", 1);
                    animator.SetFloat("Vertical", 0);
                }
            }
        }
        animator.SetBool("IsMoving", isMoving);
        familiarGridMovement.animator.SetBool("IsMoving", isMoving);
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
