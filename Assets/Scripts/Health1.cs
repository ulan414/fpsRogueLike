/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;
public class Health1 : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBar changeHealth;
    public bool isBot = true;
    public Vector3 playerTeleportAfterDeathPosition = new Vector3(0f,0f,0f);
    public GameOverScreen GameOverScreen;
    //script myScript;
    // Start is called before the first frame update
    void Start()
    {
        changeHealth.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDammage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //make smthng with player after death
            GameOverScreen.Setup();
            gameObject.GetComponent<Collider>().enabled = false;
            //myScript = gameObject.GetComponent<Movement>();
            //gameObject.GetComponent<Character>().enabled = false;
            //gameObject.GetComponent<Character>().Movement = false;

        }
        changeHealth.SetHealth(health);
    }
    public void AddHealth(int bonusHealth)
    {
        health += bonusHealth;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        changeHealth.SetHealth(health);
    }
}
*/