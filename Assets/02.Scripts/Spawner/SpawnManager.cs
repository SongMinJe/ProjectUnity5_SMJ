using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //로비에서는 플레이어만 스폰
    //스테이지 이동시 스테이지의 고유 넘버를 부여
    public int stageNum = 0;
    public GameObject player;
    public GameObject enemy;
    public Transform[] spawner;
    
    private bool isPlayerSpawned = false;

    private void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        if (!isPlayerSpawned)
        {
            Instantiate(player, spawner[0].position, spawner[0].rotation);
            isPlayerSpawned = true;
        }
        if (stageNum >= 1)
        {
            Instantiate(enemy, spawner[stageNum].position, spawner[stageNum].rotation);
        }

    }
}
