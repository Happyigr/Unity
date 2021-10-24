using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
    // main stats
    public float Damage;
    public float HitRate;
    public Sword SwordPrefab;

    // components links
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();   
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Hit();
        }
    }

    private void Hit()
    {
        // ask sword to play an animation of hit
        SwordPrefab.Hit();
    }
}
