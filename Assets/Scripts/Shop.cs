using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint laserTurret;
    public TurretBlueprint rocketTurret;
    public TurretBlueprint fireTurret;
    public TurretBlueprint moneyTurret;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    //this will happend when you click on the turret button
    public void SelectLaserTurret()
    {
        //will allow you to buy the laser turret
        Debug.Log("laser turret selected");
        gameManager.SelectTurretToBuild(laserTurret);
    }
    //this function will happen when you click on the rocket button
    public void SelectRocketTurret()
    {
        //will allow you to buy the rocket turret
        Debug.Log(" Rocket turret selected");
        gameManager.SelectTurretToBuild(rocketTurret);
    }
    //this function will happen when you click on the fire button
    public void SelectFireTurret()
    {
        //will allow you to buy the fire turret
        Debug.Log("Fire turret selected");
        gameManager.SelectTurretToBuild(fireTurret);
    }
    //this function will happen when you click on the money button
    public void SelectMoneyTurret()
    {
        //will allow you to buy the money turret
        Debug.Log(" Money turret selected");
        gameManager.SelectTurretToBuild(moneyTurret);
    }

}
