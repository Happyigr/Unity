using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Sword : MonoBehaviour
{
    // main settings
    public SwordHit SwordHitPrefab;

    // main links
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Hit()
    {
        // sword play a hit animation
        anim.SetTrigger("hit");
        // ask swordhit to play an animation in his coords
        SwordHitPrefab.HitAnimPlay();
    }
}
