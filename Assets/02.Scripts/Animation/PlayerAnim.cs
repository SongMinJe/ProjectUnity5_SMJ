using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator anim;

    public void IsAtk()
    {
        anim.SetTrigger("Atk");
    }

    public void IsHit(bool isHit)
    {
        anim.SetBool("IsHit", isHit);
    }
}
