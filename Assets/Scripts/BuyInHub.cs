using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyInHub : Balance
{
    int cost = 1000;
    //int balance = 0;
    public void CanBuy()
    {
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
    }
    void CannotBuy()
    {
        Debug.Log("cannot buy");
    }
    void Upgrade()
    {

    }
}
