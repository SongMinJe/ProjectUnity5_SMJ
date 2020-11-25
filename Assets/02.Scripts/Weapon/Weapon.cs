using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Stats stats;
    public float damage;
    public float attackSpeed;
    protected virtual void SetStats()
    {

    }
}
