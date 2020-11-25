using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //추후 추가되는 적만의 고유한 Stats
    private Stats stats;

    public float hp;
    public float damage;
    public float speed;
    public float attackSpeed;

    private void Start()
    {
        SetStats();
    }

    public void SetStats()
    {
        stats.hp = hp;
        stats.damage = damage; //무기를 가지고 있다면 WeaponHandler의 자식의 무기 클래스의 스탯을 가져와 저장한다.
        stats.speed = speed;
        stats.attackSpeed = attackSpeed;
    }

    public void ReduceHp(float damage)
    {
        hp -= damage;
        if (hp > 0)
        {
            Debug.Log("EnemyHp : " + hp);
        }
        else if (hp <= 0)
        {
            hp = 0;
            Debug.Log("Enemy Dead!");
        }
    }
}
