using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    float shootSpeed = 12f;
    Rigidbody2D myRigid;

    float deleteTime=2; 

    void Start()
    {
        //Vector3.right ->월드세계 기준
        //transform.right -> 나의 세계 기준 

        myRigid = GetComponent<Rigidbody2D>();
        myRigid.AddForce(transform.right*shootSpeed, ForceMode2D.Impulse );

        Destroy(gameObject, deleteTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.SetParent(other.transform);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated=false;
    }

}
