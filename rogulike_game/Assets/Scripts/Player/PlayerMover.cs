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
            animtor.SetBool("isRunning", false);        
        }

        // stop all forces, that control the object
        playersRigid.velocity = new Vector2(0, 0);
        // moving a player
        playersRigid.AddForce(moveVector * ForcePower);

    }
}
