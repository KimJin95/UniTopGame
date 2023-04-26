using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGenManager : MonoBehaviour
{
    ObjectGenPoint[] genPoints;

    void Start()
    {
        //genPoints = GetComponentsInChildren<ObjectGenPoint>();
        genPoints = GameObject.FindObjectsOfType<ObjectGenPoint>();
    }

    void Update()
    {
        ItemData[] items = GameObject.FindObjectsOfType<ItemData>();

        foreach (var item in items)
        {
            if (item.type == ItemType.arrow) return;    
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (ItemKeeper.hasArrows == 0 && player != null)
        {
            int index = Random.Range(0, genPoints.Length);
            genPoints[index].ObjectCreate();
        }

    }
}
