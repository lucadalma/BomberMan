using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public float bombRatioPlacement;
    public float maxBombRatioPlacement;

    [SerializeField]
    public float movementSpeed;

    bool onRegenBomb = false;
    private IEnumerator coroutine;

    private void Start()
    {
        maxBombRatioPlacement = bombRatioPlacement;
    }

    private void Update()
    {
        if (bombRatioPlacement < maxBombRatioPlacement && onRegenBomb == false)
        {
            onRegenBomb = true;
            coroutine = RegenBomb();
            StartCoroutine(coroutine);
        }
    }

    IEnumerator RegenBomb()
    {
        bombRatioPlacement += 1;
        yield return new WaitForSeconds(1);
        onRegenBomb = false;
    }

}
