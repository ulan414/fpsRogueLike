using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public AI Bot;
    public AI Bot1;
    public HealthText helathtext;
    public HealthBar changeHealth;
    public bool isBot = true;
    public Vector3 playerTeleportAfterDeathPosition = new Vector3(0f,0f,0f);
    //public GameOverScreen GameOverScreen;
    private GameObject DeathScreen;
    public GameObject canvas;
    float timer = 0f;
    private GameOverScreen GameOverScreen;
    //script myScript;
    // Start is called before the first frame update
    void Start()
    {
        changeHealth.SetMaxHealth(maxHealth);
        DeathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
        
        GameOverScreen = DeathScreen.GetComponentInChildren<GameOverScreen>(true);
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
            if (isBot)
            {
                GameOverScreen.AddPoints(1);
                AI ai = gameObject.GetComponent<AI>();
                ai.dying = true;
            }
            else
            {
                //make smthng with player after death
                GameOverScreen.Setup();
                //myScript = gameObject.GetComponent<Movement>();
                //gameObject.GetComponent<Character>().enabled = false;
                if (Bot != null)
                {
                    Destroy(Bot.gameObject);
                }
                if (Bot1 != null)
                {
                    Destroy(Bot1.gameObject);
                }
                Destroy(helathtext);
                gameObject.GetComponent<Character>().enabled = false;
                Destroy(gameObject.GetComponent<Movement>());
                //gameObject.GetComponent<Movement>().enabled = false;
                Destroy(gameObject.GetComponent<Rigidbody>(),0.1f);
                gameObject.GetComponent<Collider>().enabled = false;

                //gameObject.GetComponent<PlayerInput>().enabled = false;

                foreach (Transform t in transform)
                {
                    foreach (Component com in t.GetComponents<Component>())
                    {
                        if (com != t.GetComponent<Transform>())
                            Destroy(com);
                    }
                }
                //Destroy(gameObject,1);
                //disabling canvas in hierarchy
                    canvas.SetActive(false);
                //disabling prefabed canvas
                GameObject tempObject = GameObject.Find("P_LPSP_UI_Canvas(Clone)");
                Canvas EscCan;
                    //If we found the object , get the Canvas component from it.
                EscCan = tempObject.GetComponent<Canvas>();
                EscCan.enabled = false;
                //escape
                //SendKeys.Send("ENTER");
                //InputBroker.SetKeyDown("Escape");
                //Input.GetKey(KeyCode.Escape);
                //Cursor.visible = true;
            }
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
