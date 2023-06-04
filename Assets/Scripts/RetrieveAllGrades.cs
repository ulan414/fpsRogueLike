using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class RetrieveAllGrades : MonoBehaviour
{
    int counter = 0;

    [SerializeField] Weapon gun;
    [SerializeField] Weapon pistol;
    [SerializeField] Magazine magazineMain;
    [SerializeField] Magazine magazineSecondary;
    [SerializeField] Grenade greanade;

    void Start()
    {
        //getUpgrades that you buy in hub
        RetrieveUpgrades();
    }

    void RetrieveUpgrades()
    {
        if (PlayerPrefs.HasKey("AmountOfGrades"))
        {
            counter = PlayerPrefs.GetInt("AmountOfGrades");
        }
        else
        {
            return;
        }
        for (int i = 0; i < counter; i++)
        {
            string Id = i.ToString();
            if (PlayerPrefs.HasKey(Id))
            {
                int gradeLevel = PlayerPrefs.GetInt(Id);
                for(int j = 0; j < gradeLevel; j++)
                {
                    Upgrade(i);
                }
            }
        }
    }
    void Upgrade(int ID)
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
}
