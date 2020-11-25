using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : MonoBehaviour
{
    public Player player;

    public Button btnAtk;

    private void Start()
    {
        Invoke("FindPlayerObj", 0.1f);
    }

    public void FindPlayerObj()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        btnAtk = GameObject.Find("Btn_Attack").GetComponent<Button>();
    }

    public void AtkBtnDown()
    {
        player.Attack();
    }

    public void AtkBtnUp()
    {

    }
}
