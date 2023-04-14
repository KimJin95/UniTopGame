using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    [SerializeField] GameObject bowPrefab;
    [SerializeField] GameObject arrowPrefab;

    GameObject bow;
    PlayerMove player;

    bool inAttack;
    void Start()
    {
        bow = Instantiate(bowPrefab, transform.position, Quaternion.identity);
        bow.transform.SetParent(transform);
        player = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //if i press the button(fire3) and inAttack is false then can attack
        if (Input.GetButtonDown("Fire3") && inAttack == false)  //Use Timer => For No consecutive attacks
            StartCoroutine(Attack());




        float bowZ = -1; //

        if (player.angleZ >= 30 && player.angleZ <= 150) bowZ = 1;


        bow.transform.rotation = Quaternion.Euler(0, 0, player.angleZ);

        //z만 수정x => 개별 수정 불가
        Vector3 pos = bow.transform.position;
        pos.z = bowZ;
        bow.transform.position = pos;
    }

    private IEnumerator Attack()
    {
        yield return null;
    }
}
