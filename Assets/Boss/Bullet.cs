using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D myRigid;
    float shootspeed = 5;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();

        myRigid.AddForce(transform.right*shootspeed,ForceMode2D.Impulse);

        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
