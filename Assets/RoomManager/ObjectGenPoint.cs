using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenPoint : MonoBehaviour
{
    [SerializeField] GameObject objPrefab;

    public void ObjectCreate()
    {
        Instantiate(objPrefab,transform.position,Quaternion.identity);

    }
  
}
