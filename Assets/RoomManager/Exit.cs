using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ExitDirection { right,keft,down,up}

public class Exit : MonoBehaviour
{

    [SerializeField] string sceneName;
    [SerializeField] int doorNumber;
    [SerializeField] ExitDirection direction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);  
        }
    }

}
