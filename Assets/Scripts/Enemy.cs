using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Image healthBar;

    [SerializeField] float startHp = 100f;
    private float hp;

    [SerializeField] int moneyAward;


    private void Start()
    {
        hp = startHp;
    }

    public void Hit(int damage)
    {
        hp -= damage;
        healthBar.fillAmount = hp / startHp;
        if (hp <= 0)
        {
            PlayerStats.money += moneyAward;
            Destroy(gameObject);
            
        }
    }
}
