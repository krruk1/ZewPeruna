using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;
    public static int lifes;
    public int startLifes = 3; 
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI lifesText;
    [SerializeField] SceneLoader sceneLoader;

    private void Start()
    {
        money = startMoney;
        lifes = startLifes;
    }

    private void Update()
    {
        moneyText.text = money.ToString() + "$";
        lifesText.text = lifes.ToString() + " hp";
        if(lifes <= 0 )
        {
            sceneLoader.LoadGameOverScene();
        }


    }
}
