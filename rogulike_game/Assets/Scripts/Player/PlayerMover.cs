using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    // main settings
    public int ForcePower; // players movement speed

    // parametrs of player
    private Vector3 moveVector;
    private bool isRightRunning = true;

    // link to components
    private Animator animtor; // players animator
    private Rigidbody2D playersRigid; // players rigidbody

    private void Start()
    {
        animtor = gameObject.GetComponent<Animator>();
        playersRigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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

        // stop all forces, that control the object
        playersRigid.velocity = new Vector2(0, 0);
        // moving a player
        playersRigid.AddForce(moveVector * ForcePower);

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
