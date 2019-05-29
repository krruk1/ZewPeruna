using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp = 100;

    [SerializeField] int moneyAward;

    public void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            PlayerStats.money += moneyAward;
            Destroy(gameObject);
            
        }
    }
}
