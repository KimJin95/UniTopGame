using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static int hp = 3;
    public static string gameState = "playing";
    bool inDamage = false;
    float delayTime = 0.25f;
    SpriteRenderer myRender;

    //변수 -> 이동

    [SerializeField] float speed;

    float axisH, axisV;

    Rigidbody2D myRigid;

    Animator myAnimator;
    Transform myTr;
    public float angleZ = -90;
    string upAnim = "PlayerUp";
    string downAnim = "PlayerDown";
    string rightAnim = "PlayerRight";
    string leftAnim = "PlayerLeft";
    string deadAnim = "PlayerDead";

    string nowAnimation; //now animation
    string oldAnimation; //old animation
    bool isMoving = false;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRender = GetComponent<SpriteRenderer>();
        myTr = transform;

    }


    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");

        SetAnimation();
    }

    private void FixedUpdate()
    {
        if (gameState != "playing") return;

        if (inDamage)
        {
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0) myRender.enabled = true;
            else myRender.enabled = false;
            return;
        }


        myRigid.velocity = new Vector2(axisH, axisV) * speed;
    }

    void SetAnimation()
    {
        Vector2 fromPt = myTr.position;
        Vector2 toPt = myTr.position + new Vector3(axisH, axisV);
        angleZ = GetAngle(fromPt, toPt);

        if (angleZ >= -45 && angleZ < 45) nowAnimation = rightAnim;
        else if (angleZ >= 45 && angleZ < 135) nowAnimation = upAnim;
        else if (angleZ >= -135 && angleZ < -45) nowAnimation = downAnim;
        else nowAnimation = leftAnim;

        if (oldAnimation != nowAnimation)
        {
            oldAnimation = nowAnimation;
            myAnimator.Play(nowAnimation);
        }
    }

    private float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle = 0; //지역변수 - 초기값 필수 

        if (axisH != 0 || axisV != 0)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float rad = Mathf.Atan2(dy, dx);
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }

        return angle;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            StartCoroutine(GetDamage(other.transform));
        }
    }

    IEnumerator GetDamage(Transform enemy)
    {
        if (gameState != "playing") yield break; //return;

        inDamage = true;

        //if player take the damage then make hp minus 1 and move back (opposite enemy)
        hp--;
        if (hp > 0) //if player still alive
        {
            myRigid.velocity = Vector2.zero;
            Vector2 toPos = (myTr.position - enemy.position).normalized;
            myRigid.AddForce(toPos * 4, ForceMode2D.Impulse);

        }
        else Gameover();


        yield return new WaitForSeconds(delayTime);

        inDamage = false;
        myRender.enabled = true;

    }

    private void Gameover()
    {
     
        gameState = "gameover";

        GetComponent<CircleCollider2D>().enabled = false;
        myRigid.velocity = Vector2.zero;
        myRigid.gravityScale = 1;
        myRigid.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        myAnimator.Play(deadAnim);
        Destroy(gameObject, 1);
    }
}
