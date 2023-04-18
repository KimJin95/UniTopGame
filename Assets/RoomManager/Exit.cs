using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ExitDirection { right,left,down,up}

public class Exit : MonoBehaviour
{

    [SerializeField] string sceneName;
    public int doorNumber;
    public ExitDirection direction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           RoomManager.ChangeScene(sceneName,doorNumber);

        }
    }

}
