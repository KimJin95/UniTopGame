using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make item
//change open image

public class ItemBox : MonoBehaviour
{

    public int arrangeId;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Sprite openImage;


    bool isClosed = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isClosed && other.transform.CompareTag("Player"))
        {
            isClosed = false;

            if (itemPrefab != null)
            {
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }

            GetComponent<SpriteRenderer>().sprite = openImage;
        }
    }

}
