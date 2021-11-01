using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMainScript : MonoBehaviour
{
    // main links
    public Player Player;

    // private things
    private Transform playerTransform;

    private void Start()
    {
         playerTransform = Player.GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
    }
}
