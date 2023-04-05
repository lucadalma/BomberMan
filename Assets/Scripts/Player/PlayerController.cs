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

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer() 
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Debug.Log(inputX);

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

}
