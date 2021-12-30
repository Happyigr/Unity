using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTracker : MonoBehaviour
{
    // main public fields
    public Transform PointOfRotate;

    // main private fields
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        var cursorPosition = Input.mousePosition;
        // becoming a of mouse
        var worldCursorPosition = _mainCamera.ScreenToWorldPoint(cursorPosition) + new Vector3(0, 0, 10);
        // getting normalized vector of direction
        var normalizedDirectionVector = (transform.localPosition - worldCursorPosition).normalized;

    }

    // gameobject assets flip method
    private void xFlip()
    {
        // getting a size of player
        Vector3 theScale = transform.localScale;
        // mirroring a player for axis x
        theScale.x *= -1;
        // assign a mirrored picture of player
        transform.localScale = theScale;
    }
}
