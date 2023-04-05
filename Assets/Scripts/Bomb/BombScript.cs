using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField]
    public GameObject explosion;

    public PlayerStats playerStats;

    private IEnumerator coroutine1;
    private IEnumerator coroutine2;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NonDestructibleWall") || collision.gameObject.CompareTag("DestructibleWall"))
        {
            playerStats.bombRatioPlacement = playerStats.maxBombRatioPlacement;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        coroutine1 = BombExplosion();
        coroutine2 = BombDestory();
        StartCoroutine(coroutine1);
        StartCoroutine(coroutine2);
    }

    IEnumerator BombDestory() 
    {
        yield return new WaitForSeconds(3);
        explosion.SetActive(true);
        Destroy(gameObject);
    }

    IEnumerator BombExplosion()
    {
        yield return new WaitForSeconds(2);
        explosion.SetActive(true);
    }

}

