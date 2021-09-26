using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTurret : MonoBehaviour
{
    GameManager gameManager;
    public int setMoney;
    public int maxMoney;
    public float generatetimer;
    public bool startedwave;
    //its only generateing money during the wave and not in between boolean called wavestarted

    private void Start()
    {
        setMoney = maxMoney;
        gameManager.money = maxMoney;
        gameManager.money += setMoney;
    }
    public void GenerateMoney()
    {
        
    }
}
