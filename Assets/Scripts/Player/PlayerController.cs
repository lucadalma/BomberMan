using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerStats playerStats;
    Rigidbody2D rb;
    
    [SerializeField]
    GameObject orientation;

    [SerializeField]
    GameObject bomb;

    [SerializeField]
    GameObject bombPosition;

    GameManager gm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            gm.gameStatus = GameManager.GameStatus.EndGame;
            gm.gameResult = GameManager.GameResult.GameOver;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BombExplosion"))
        {
            gm.gameStatus = GameManager.GameStatus.EndGame;
            gm.gameResult = GameManager.GameResult.GameOver;
        }
    }

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        PlaceBomb();
    }

    public void MovePlayer() 
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        if (inputX > 0)
        {
            orientation.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
        }
        else if (inputX < 0) 
        {
            orientation.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
        }

        if (inputY > 0)
        {
            orientation.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (inputY < 0)
        {
            orientation.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }

        Vector3 movement = new Vector3(playerStats.movementSpeed * inputX, playerStats.movementSpeed * inputY, 0);

        rb.velocity = movement;

    }

    public void PlaceBomb() 
    {
        if (Input.GetButtonDown("Jump") && playerStats.bombRatioPlacement == playerStats.maxBombRatioPlacement) 
        {
            playerStats.bombRatioPlacement = 0;
            Instantiate(bomb, bombPosition.transform.position, Quaternion.identity);
        }
    }

}
