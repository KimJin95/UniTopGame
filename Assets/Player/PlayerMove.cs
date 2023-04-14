using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
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

    string nowAnimation; //now animation
    string oldAnimation; //old animation
    bool isMoving = false;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myTr = GetComponent<Transform>();
    }


    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");

        SetAnimation();
    }

    private void FixedUpdate()
    {
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
}
