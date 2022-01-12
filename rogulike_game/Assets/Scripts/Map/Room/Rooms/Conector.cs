using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conector : MonoBehaviour
{
    public Side Side;

    private bool _isBusy = false;

    public bool IsBlocked()
    {
        return _isBusy;
    }

    public void Block()
    {
        _isBusy = true;
    }
}
