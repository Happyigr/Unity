using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    // main settings
    public int moveSpeed; // players movement speed

    // parametrs of player
    private Vector3 moveVector;
    private bool isRightRunning = true;

    // link to components
    private Animator animtor; // players animator

    private void Start()
    {
        animtor = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // characters move directions
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        if(moveVector != Vector3.zero)
        {
            animtor.SetBool("isRunning", true); // if character running play an animation
        }
        else
        {
            animtor.SetBool("isRunning", false);        }

        // flipping a player if player is running in the other direction
        if (moveVector.x > 0 && !isRightRunning)
        {
            xFlip();
        }
        else if (moveVector.x < 0 && isRightRunning)
        {
            xFlip();
        }

        // moving a player
        transform.position += (moveVector * moveSpeed * Time.deltaTime);

    }

    // player's assets flip method
    private void xFlip()
    {
        // switch a bool with direction of player
        isRightRunning = !isRightRunning;
        // getting a size of player
        Vector3 theScale = transform.localScale;
        // mirroring a player for axis x
        theScale.x *= -1;
        // assign a mirrored picture of player
        transform.localScale = theScale;
    }
}
