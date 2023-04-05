using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{

    [SerializeField]
    GameObject floor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BombExplosion"))
        {
            Instantiate(floor, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
