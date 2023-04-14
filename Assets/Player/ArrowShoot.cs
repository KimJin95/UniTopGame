using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    [SerializeField] GameObject bowPrefab;
    [SerializeField] GameObject arrowPrefab;

    GameObject bow;
    void Start()
    {
        bow = Instantiate(bowPrefab, transform.position, Quaternion.identity);
        bow.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
