using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    public int arrangeId;

    [SerializeField] int hp;
    [SerializeField] float speed;
    [SerializeField] float reactionDistance;

    Rigidbody2D myRigid;
    Animator myAnim;

    float axisH, axisV;

    Transform playerTr;


    string upAnim = "EnemyUp";
    string downAnim = "EnemyDown";
    string rightAnim = "EnemyRight";
    string leftAnim = "EnemyLeft";
    string deadAnim = "EnemyDead";
    string IdleAnim = "EnemyIdle";

    string nowAnimation; //now animation
    string oldAnimation; //old animation

    bool isActive = false;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (playerTr != null)
        {
            if (isActive)
            {
                SetAnimation();
            }
            else
            {
                float dist = Vector2.Distance(transform.position, playerTr.position);
                if (dist < reactionDistance) isActive = true;
            }
        }
        else
        {
            isActive = false;
            myRigid.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (isActive && hp > 0)
        {
            myRigid.velocity = new Vector2(axisH, axisV);

        }
    }

    void SetAnimation()
    {
        float dx = playerTr.position.x - transform.position.x;
        float dy = playerTr.position.y - transform.position.y;

        float rad = Mathf.Atan2(dy, dx);
        axisH = dx * speed;  //axisH = Mathf.Cos(rad) * speed;
        axisV = dy * speed;  //axisV = Mathf.Sin(rad) * speed; 

        float angleZ = rad * Mathf.Rad2Deg;

        if (angleZ >= -45 && angleZ < 45) nowAnimation = rightAnim;
        else if (angleZ >= 45 && angleZ < 135) nowAnimation = upAnim;
        else if (angleZ >= -135 && angleZ < -45) nowAnimation = downAnim;
        else nowAnimation = leftAnim;

        if (oldAnimation != nowAnimation)
        {
            oldAnimation = nowAnimation;
            myAnim.Play(nowAnimation);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Arrow"))
        {
            hp--;
            if (hp <= 0)
            {

                GetComponent<CircleCollider2D>().enabled = false;

                myRigid.velocity = Vector2.zero;

                myAnim.Play(deadAnim);

                Destroy(gameObject, 0.5f);
                
            }
        }
    }
}
