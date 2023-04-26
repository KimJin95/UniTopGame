using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform bossTr;

   

    void LateUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (bossTr != null)
            {
                Vector3 pos = Vector3.Lerp(player.transform.position, bossTr.position, 0.5f); //둘 사이의 한가운데 카메라가 위치
                transform.position = new Vector3(pos.x, pos.y, -10);

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
