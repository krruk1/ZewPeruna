using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int moneyAward;
    private void OnDestroy()
    {
        PlayerStats.money += moneyAward;
    }
}
