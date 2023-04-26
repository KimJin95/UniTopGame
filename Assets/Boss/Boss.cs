using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    float shootSpeed = 5f;

    int hp = 10;
    float reactionDistance = 4f;

    bool inAttack = false;

    Animator myAnim;
    Transform playerTr;
    Transform myTr;
    Transform gateTr;
    void Start()
    {
        myAnim = GetComponent<Animator>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        myTr = transform;
        gateTr = transform.Find("gate");
    }


    void Update()
    {
        if (hp > 0) //attack
        {
            if (playerTr != null)
            {
                float dist = Vector3.Distance(myTr.position, playerTr.position);

                if (dist <= reactionDistance && inAttack == false) //공격범위 내
                {
                    inAttack = true;
                    myAnim.Play("BossAttack"); //애니메이션 실행 시 총알 발사

                }
                else if (dist > reactionDistance && inAttack)
                {
                    inAttack = false;
                    myAnim.Play("BossIdle");
                }
            }
            else
            {
                inAttack = false;
                myAnim.Play("BossIdle");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Arrow"))
        {
            if (--hp <= 0)
            {
                myAnim.Play("BossDead");
                GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject, 2);
            }
        }
    }
    void Attack()
    {
        if (playerTr == null) return;

        float dx = playerTr.position.x - gateTr.position.x;
        float dy = playerTr.position.y - gateTr.position.y;

        float rad = Mathf.Atan2(dy, dx);
        float rot = rad * Mathf.Rad2Deg;

        Quaternion r = Quaternion.Euler(0, 0, rot);

        Instantiate(bulletPrefab, gateTr.position, r);
    }
}
