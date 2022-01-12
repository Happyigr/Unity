using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public GameObject Container;
    public int Amount;

    public abstract void Spawn(int amount);
}
