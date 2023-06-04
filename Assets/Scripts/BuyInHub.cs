using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class BuyInHub : MonoBehaviour
{
    [SerializeField] Balance balance;
    int cost = 1000;
    public int ID = 0;
    int gradeLevel = 0;
    int counter = 0;
    [SerializeField] Weapon gun;
    [SerializeField] Weapon pistol;
    [SerializeField] Magazine magazineMain;
    [SerializeField] Magazine magazineSecondary;
    [SerializeField] Grenade greanade;
    //int balance = 0;
    public void CanBuy()
    {
        Debug.Log(ID);
        if (balance.money >= cost)
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
        if (gradeLevel > 4)
            return;
        gradeLevel++;
        Debug.Log("bought");
        balance.money -= cost;
        Upgrade();
        //enable star
        Transform childTransform = transform.Find("Stars/" + gradeLevel + "/star_full");
        if (childTransform != null)
        {
            GameObject childObject = childTransform.gameObject;
            childObject.SetActive(true);
        }
        balance.UpdateBalance();
        SaveUpgrades(ID, gradeLevel);
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
                //main weapon + magaz + 3 bullets
                magazineMain.setAmmo(3);
                break;
            case 4:
                //weapon reload - 0.1sec
                break;
            case 5:
                //secondary weapon + magaz + 3 bullets
                magazineSecondary.setAmmo(2);
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
                //grenade damage + 6%
                greanade.Blaster(6);
                break;
            default:
                Debug.Log("Number is not between 1 and 10");
                break;
        }
    }
    void SaveUpgrades(int id, int gradeLevel)
    {
        string Id = id.ToString();
        PlayerPrefs.SetInt(Id, gradeLevel);

        counter++;
        if(PlayerPrefs.HasKey("AmountOfGrades"))
            counter += PlayerPrefs.GetInt("AmountOfGrades");
        PlayerPrefs.SetInt("AmountOfGrades", counter);
    }
}
