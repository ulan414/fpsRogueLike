using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public Text hpText;
    public GameObject player;
    private float playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<Health>().health;
        hpText.text = playerHealth.ToString();
    }
}
