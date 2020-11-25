using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private EnemyStats enemyStats;

    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Move()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Debug.Log("Enemy : Attacked!");
            enemyStats.ReduceHp(collision.gameObject.GetComponent<Rappier>().damage);
        }
    }
}
