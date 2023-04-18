using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public int arrangeId = 0;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (ItemKeeper.hasKeys > 0)
            {
                ItemKeeper.hasKeys--;
                Destroy(this.gameObject);
            }


        }
    }
}
