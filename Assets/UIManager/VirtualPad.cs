using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class VirtualPad : MonoBehaviour
{
    [SerializeField] bool is4DPad = true;
    PlayerMove player;

    ArrowShoot playerAt;

    Vector3 defPos; //초기위치
    Vector3 downPos; //터치한 위치

    RectTransform myTr;

    float maxLength=60;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

        player = FindObjectOfType<PlayerMove>();
        playerAt = FindObjectOfType<ArrowShoot>();

        myTr = GetComponent<RectTransform>();
        defPos = myTr.localPosition;
    }

    public void PadDown()
    {
        downPos=Input.mousePosition;
    }

    public void PadDrag()
    {
        Vector3 newTabPos = Input.mousePosition - downPos;

        //크기가 1인 방향만 존재하는 정규화 벡터
        Vector3 axis = newTabPos.normalized;

        float len = Vector3.Distance(defPos, newTabPos);

        if (len > maxLength)
        {
            newTabPos=axis*maxLength;
        }

        myTr.localPosition = newTabPos;
        player.SetAxis(axis.x,axis.y);
    }

    public void Padup()
    {
        myTr.localPosition = defPos;
        player.SetAxis(0, 0);
    }

    public void Attack()
    {
        StartCoroutine(playerAt.Attack());
    }


}
