using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
    // main stats
    public float Damage;
    public Sword SwordPrefab;
    public float AttackPerSecond;
    public float RangeOfAttack = 0.5f;
    public Transform AttackPoint;

    // private stats
    private float hitsTimeInSecond;
    private float nextHitTime = 0;

    // important comp
    public LayerMask EnemyLayers;

    // components links
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        // count hits per second
        hitsTimeInSecond = 1 / AttackPerSecond;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextHitTime)
        {
            nextHitTime = Time.time + hitsTimeInSecond;
            Hit();
        }
    }

    private void Hit()
    {
        // ask sword to play an animation of hit
        SwordPrefab.Hit();

        // detect all enemyes in range of attack
        Collider2D[] hittedEnemyes = Physics2D.OverlapCircleAll(AttackPoint.position, RangeOfAttack, EnemyLayers);

        // hit them
        foreach (Collider2D enemy in hittedEnemyes)
        {
            Debug.Log("enemy is hitted");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(AttackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(AttackPoint.position, RangeOfAttack);
    }
}
