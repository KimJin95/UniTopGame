using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType { key, arrow, life }
public class ItemData : MonoBehaviour
{
    public int arrangeId;

    [SerializeField] ItemType type;
    [SerializeField] int count;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;

        switch (type)
        {
            case ItemType.key: ItemKeeper.hasKeys += count;
                break;
            case ItemType.arrow: ItemKeeper.hasArrows += count;
                break;
            case ItemType.life:
                if (PlayerMove.hp < 3)
                {
                    PlayerMove.hp += count;
                    PlayerPrefs.SetInt("PlayerHp", PlayerMove.hp);
                }

                break;
        }

        GetComponent<CircleCollider2D>().enabled = false;

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (rigid !=null)
        {
            rigid.gravityScale = 2.5f;
            rigid.AddForce(Vector2.up * 6, ForceMode2D.Impulse);

        }


        Destroy(gameObject,0.5f);

    }

}
