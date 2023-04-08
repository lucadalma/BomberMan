using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    [SerializeField]
    public GameObject DestructibleWall;

    [SerializeField]
    public GameObject NonDestructibleWall;

    [SerializeField]
    public GameObject Floor;

    float[,] levelMatrix;

    [SerializeField]
    public int XLenghtLevel;

    [SerializeField]
    public int YLenghtLevel;

    void Start()
    {
        levelMatrix = new float[XLenghtLevel, YLenghtLevel];
        CreateLevel();
    }

    void Update()
    {
        
    }

    public void CreateLevel() 
    {
        for (int i = 0; i < XLenghtLevel; i++)
        {
            Instantiate(NonDestructibleWall, new Vector3((i - 0.5f), (-1.5f)), Quaternion.identity);
            float lastJ = 0;
            for (int j = 0; j < YLenghtLevel; j++)
            {
                
                if (i % 2 != 0 && j % 2 != 0)
                {
                    Instantiate(NonDestructibleWall, new Vector3((i - 0.5f), (j - 0.5f)), Quaternion.identity);
                }
                else 
                {
                    float randomChance = Random.Range(0, 11);
                    Debug.Log(randomChance);
                    if (randomChance >= 9)
                    {
                        Instantiate(DestructibleWall, new Vector3((i - 0.5f), (j - 0.5f)), Quaternion.identity);
                    }
                    else 
                    {
                        Instantiate(Floor, new Vector3((i - 0.5f), (j - 0.5f)), Quaternion.identity);       
                    }
                }
                lastJ = j;
                Instantiate(NonDestructibleWall, new Vector3((-1.5f), (j - 0.5f)), Quaternion.identity);
                Instantiate(NonDestructibleWall, new Vector3((YLenghtLevel - 0.5f), (j - 0.5f)), Quaternion.identity);
            }

            Instantiate(NonDestructibleWall, new Vector3((i - 0.5f), (lastJ + 0.5f)), Quaternion.identity);

        }
    }
}
