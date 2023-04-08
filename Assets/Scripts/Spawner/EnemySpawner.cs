using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager gm;

    [SerializeField]
    GameObject enemy;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        for (int i = 0; i < gm.numberEnemy; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
