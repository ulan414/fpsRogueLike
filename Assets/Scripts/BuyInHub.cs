using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class BuyInHub : Balance
{
    int cost = 1000;
    public int ID = 0;
    [SerializeField] Weapon gun;
    [SerializeField] Weapon pistol;
    //int balance = 0;
    public void CanBuy()
    {
        Debug.Log(ID);
        if (balance >= cost)
        {
            Buy();
        }
        else
        {
            CannotBuy();
        }
    }
    void Buy()
    {
        Debug.Log("bought");
        balance -= cost;
        Upgrade();
        //enable star
        //Transform child1Transform = transform.Find("Child1");
    }
    void CannotBuy()
    {
        Debug.Log("cannot buy");
    }
    void Upgrade()
    {
        switch (ID)
        {
            case 1:
                //gun damage + 5%
                gun.AddDamage(5);
                break;
            case 2:
                //pistol damage + 5%
                pistol.AddDamage(5);
                break;
            case 3:
                //weapon reload - 0.1sec
                break;
            case 4:
                Debug.Log("Number is 4");
                break;
            case 5:
                Debug.Log("Number is 5");
                break;
            case 6:
                Debug.Log("Number is 6");
                break;
            case 7:
                Debug.Log("Number is 7");
                break;
            case 8:
                Debug.Log("Number is 8");
                break;
            case 9:
                Debug.Log("Number is 9");
                break;
            case 10:
                Debug.Log("Number is 10");
                break;
            default:
                Debug.Log("Number is not between 1 and 10");
                break;
        }

    }
}
