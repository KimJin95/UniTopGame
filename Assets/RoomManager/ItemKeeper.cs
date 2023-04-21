using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKeeper : MonoBehaviour
{
    public static int hasKeys;
    public static int hasArrows;

    private void Start()
    {
        //Load
        hasKeys = PlayerPrefs.GetInt("Keys");
        hasArrows = PlayerPrefs.GetInt("Arrows");
    }

    public static void Saveitem()
    {
        PlayerPrefs.SetInt("Keys",hasKeys);
        PlayerPrefs.SetInt("Arrows", hasArrows);
        

    }

}
