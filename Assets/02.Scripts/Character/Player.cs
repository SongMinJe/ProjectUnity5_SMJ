using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Joystick stick;
    private PlayerStats playerStats;
    private PlayerAnim playerAnim;
    private Rappier weapon;

    private Transform tr;
    private Vector3 velocity = Vector3.up;
    private Quaternion direction;
    private Rigidbody2D rb;
    private WaitForSeconds delaySec = new WaitForSeconds(0.05f);

    private bool isAtkAble = true;
    private bool isMoveAble = true;
    private float atkDelay = 0.65f;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
        playerAnim = GetComponent<PlayerAnim>();
        stick = FindObjectOfType<Joystick>();
        weapon = GameObject.Find("Rappier").GetComponent<Rappier>();
    }

    void FixedUpdate()
    {
        Move();
    }

    IEnumerator Timer(float sec)
    {
        while (true)
        {
            if(sec <= 0)
            {
                isAtkAble = true;
                break;
            }
            if (sec <= 0.325f)
            {
                isMoveAble = true;
                weapon.col.enabled = false;
            }
            sec -= 0.05f;
            yield return delaySec;
        }
    }
    
    protected override void Move()
    {
        if (stick.isTouch && isMoveAble)
        {
            direction = Quaternion.AngleAxis(stick.stickAngle, Vector3.forward);
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, direction, 20f * Time.fixedDeltaTime);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * 2f);

            if (hit.collider.CompareTag("Wall"))
            {
                rb.drag = Mathf.Infinity;
            }
            else
            {
                //rb.transform.Translate(velocity.normalized * stick.stickVec.magnitude * playerStats.speed * Time.deltaTime);
                rb.velocity = rb.transform.rotation * velocity.normalized
                    * stick.stickVec.magnitude * playerStats.speed * Time.fixedDeltaTime * 60f;
            }
        }
        //벽과의 거리가 일정 이하일 시, 정지
    }

    public override void Attack()
    {
        if (isAtkAble)
        {
            weapon.col.enabled = true;
            playerAnim.IsAtk();
            isAtkAble = false;
            isMoveAble = false;
            StartCoroutine(Timer(atkDelay));
            //플레이어는 무기를 휘두르기만 한다.
            //레이피어 클래스의 콜라이더에 닿은 오브젝트의 hp 감소 메서드
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Debug.Log("Player : Attacked!");
            playerStats.ReduceHp(collision.gameObject.GetComponent<Rappier>().damage);
        }
    }
}
