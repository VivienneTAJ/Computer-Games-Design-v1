using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    public Animator animator;

    private Vector3 currentPos;
    private Vector3 targetPos;

    private readonly float timeToMove = 0.2f;

    private bool isMoving;

    void Awake()
    {
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);
    }
    void Update()
    {     
        //COULD STILL BE ADJUSTED? -  Player slides along boundary edge when keys spammed
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") > 0)
        {
            if (!isMoving && PlayerCheckGrounded.canMoveU && PlayerCollision.canMoveU)
            {
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 1);
                StartCoroutine(MovePlayer(Vector3.forward));
            }
            else if(!PlayerCheckGrounded.canMoveU || !PlayerCollision.canMoveU)
            {
                //animator.Play("player_idle_up");
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
            }
            else if(!PlayerCheckGrounded.canMoveD || !PlayerCollision.canMoveD)
            {
                //animator.Play("player_idle");
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
            }
            else if(!PlayerCheckGrounded.canMoveL || !PlayerCollision.canMoveL)
            {
                //animator.Play("player_idle_left");
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
            }
            else if (!PlayerCheckGrounded.canMoveR || !PlayerCollision.canMoveR)
            {
                //animator.Play("player_idle_right");
                animator.SetFloat("Horizontal", 1);
                animator.SetFloat("Vertical", 0);
            }
        }
        animator.SetBool("IsMoving", isMoving);
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        currentPos = transform.position;
        targetPos = currentPos + direction.normalized;

        //playerCollision.transform.position = targetPos + direction;

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
