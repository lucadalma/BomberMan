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
            for (int j = 0; j < YLenghtLevel; j++)
            {
                if (i % 2 != 0 && j % 2 != 0)
                {
                    Instantiate(NonDestructibleWall, new Vector3((i - 0.5f), (j - 0.5f)), Quaternion.identity);
                }
                else 
                {
                    Instantiate(Floor, new Vector3((i - 0.5f), (j - 0.5f)), Quaternion.identity);       
                }
            }
        }
    }
}
