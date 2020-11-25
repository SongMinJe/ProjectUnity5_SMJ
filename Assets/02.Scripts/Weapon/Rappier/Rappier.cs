using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rappier : Weapon
{
    public Collider2D col;

    private void Start()
    {
        SetStats();
        col = GetComponent<CapsuleCollider2D>();
        col.enabled = false;
    }

    protected override void SetStats()
    {
        stats.damage = damage;
        stats.attackSpeed = attackSpeed;
    }
}
