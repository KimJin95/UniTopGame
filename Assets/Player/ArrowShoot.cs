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
    float shootDelay = 0.25f;


    void Start()
    {
        bow = Instantiate(bowPrefab, transform.position, Quaternion.identity);
        bow.transform.SetParent(transform);
        player = GetComponent<PlayerMove>();

    }

    void Update()
    {
        //if i press the button(fire3) and inAttack is false and has Arrow then can attack
        //Use Timer => For No consecutive attacks
        if (Input.GetButtonDown("Fire3") && inAttack == false && ItemKeeper.hasArrows > 0)
            StartCoroutine(Attack());

        float bowZ = -1;

        if (player.angleZ >= 30 && player.angleZ <= 150) bowZ = 1;

        bow.transform.rotation = Quaternion.Euler(0, 0, player.angleZ);

        //z만 수정x => 개별 수정 불가
        Vector3 pos = bow.transform.position;
        pos.z = bowZ;
        bow.transform.position = pos;
    }

    public IEnumerator Attack()
    {
        if (inAttack == false && ItemKeeper.hasArrows > 0)
        {

            ItemKeeper.hasArrows--;
            inAttack = true;
            SoundManager.instance.SEPlay(SEType.Shoot);

            Quaternion rot = Quaternion.Euler(0, 0, player.angleZ);
            Instantiate(arrowPrefab, transform.position, rot);

            yield return new WaitForSeconds(shootDelay);
            inAttack = false;
        }
    }
}
