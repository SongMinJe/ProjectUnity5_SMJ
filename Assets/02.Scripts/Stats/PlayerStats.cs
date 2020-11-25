using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //추후 추가되는 플레이어만의 고유한 Stats
    private Stats stats;

    public float hp;
    public float speed;

    private void Start()
    {
        SetStats();
    }

    public void SetStats()
    {
        stats.hp = hp;
        stats.speed = speed;
    }

    public void ReduceHp(float damage)
    {
        hp -= damage;
        if (hp > 0)
        {
            Debug.Log("PlayerHp : " + hp);
        }
        else if (hp <= 0)
        {
            hp = 0;
            Debug.Log("Player Dead!");
        }
    }
}
