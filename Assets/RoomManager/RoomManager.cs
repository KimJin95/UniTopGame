using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public static int doorNumber;

    void Start()
    {
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");
        Exit[] exits = FindObjectsOfType<Exit>();

        foreach (var exit in exits)
        {
            if (exit.doorNumber==doorNumber)
            {
                float x = exit.transform.position.x;
                float y = exit.transform.position.y;

                if (exit.direction == ExitDirection.up) y += 1;
                else if (exit.direction == ExitDirection.down) y -= 1;
                else if (exit.direction == ExitDirection.right) x += 1;
                else if (exit.direction == ExitDirection.left) x -= 1;

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x, y, 0);
                break;
            }

        }
    }

  public static void ChangeScene(string sceneName,int doorNum)
    {
        SceneManager.LoadScene(sceneName);
        doorNumber = doorNum; //save
    }


}
