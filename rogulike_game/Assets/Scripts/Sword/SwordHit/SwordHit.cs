using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwordHit : MonoBehaviour
{
    // main links
    private Animator anim;

    private void Start()
    {
        // get the animators link
        anim = GetComponent<Animator>();
    }

    // play animation of hit
    public void HitAnimPlay()
    {
        anim.SetTrigger("hit");
    }
}
