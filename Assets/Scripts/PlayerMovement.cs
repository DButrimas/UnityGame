using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]


public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    //Eiles tvarka pagal PlayerAnimator
    private enum WalkDirections {UP, DOWN, LEFT, RIGHT }
    [SerializeField]private int playerDirection;
    [SerializeField] private float movementSpeed;
    

    void Start()
    {
        playerDirection = (int)WalkDirections.LEFT;
        animator = GetComponent<Animator>();            // netikrinu null, nes ir taip yra require component


    }
   
    void Update()
    {
        MovePlayer();

    }

    private void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float oldX = transform.position.x;
        float oldY = transform.position.y;

        float newX = oldX + (h * movementSpeed * Time.deltaTime);
        float newY = oldY + (v * movementSpeed * Time.deltaTime);
       // Debug.Log(newX + " " + newY);

        //transform.position.Set(newX, newY, transform.position.z);
        transform.SetPositionAndRotation(new Vector3(newX, newY, transform.position.z), Quaternion.identity);
        SetAnimation(v, h);
    }

    // Parenka animacija pagal vertical ir horizontal asis
    private void SetAnimation(float v, float h)
    {
        if (v > 0)
            playerDirection = (int)WalkDirections.UP;
        else if (v < 0)
            playerDirection = (int)WalkDirections.DOWN;
        if (h < 0)
            playerDirection = (int)WalkDirections.LEFT;
        else if (h > 0)
            playerDirection = (int)WalkDirections.RIGHT;


        animator.SetInteger("WalkDirection", playerDirection);

    }

}
