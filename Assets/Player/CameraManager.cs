using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform bossTr;

    GameObject otherTarget;

    void LateUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (otherTarget != null)
            {

            }
            else
            {

                transform.position = new Vector3(player.transform.position.x,
                    player.transform.position.y, -10);
            }
            //플레이어의 위치와 연동
        }
    }
}
