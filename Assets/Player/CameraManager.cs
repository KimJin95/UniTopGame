using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject otherTarget;

    void LateUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            //플레이어의 위치와 연동
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }
}
