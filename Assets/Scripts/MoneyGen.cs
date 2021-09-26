using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGen : MonoBehaviour
{

    public float moneyGenRate = 5f;
    public float moneyGenCountdown = 5f;
    public int moneyGenMin;
    public int moneyGenMax;
    private int moneyMade;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moneyGenCountdown <= 0f)
        {
            moneyMade = Random.Range(moneyGenMin, moneyGenMax);
            moneyGenCountdown = moneyGenRate;
            GameManager.instance.money += moneyMade;
        }

        moneyGenCountdown -= Time.deltaTime;

    }
}
