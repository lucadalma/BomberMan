using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameManager gm;

    Rigidbody2D rigidbody2D;

    public float accelerationTime = 0.5f;
    public float maxSpeed = 2f;
    private Vector2 movement;
    private float timeLeft;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BombExplosion")) 
        {
            gm.numberEnemy -= 1;
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.AddForce(movement * maxSpeed);
    }
}
