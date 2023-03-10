using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private float targetHealth;
    private float timeScale = 0;
    private bool lerpingHealth = false;

    // Start is called before the first frame update
    void Start()
    {
        targetHealth = 100;
    }
    // Update is called once per frame
    private void Update()
    {
        // SetHealth(playerHealth.health);
        slider.value = Mathf.MoveTowards(slider.value,targetHealth,100 * Time.deltaTime);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        
    }

    public void SetHealth(int health)
    {
        //animated method
        /*        targetHealth = health;
                timeScale = 0;

                if (!lerpingHealth)
                    LerpHealth();*/

        //slider.value = Mathf.MoveTowards(slider.value, 1, 1 * Time.deltaTime);


        //first method
        //slider.value = health;
        targetHealth = health;
    }
    private void LerpHealth()
    {
        float speed = 2;
        float startHealth = slider.value;
        lerpingHealth = true;

        while (timeScale < 1)
        {
            timeScale += Time.deltaTime * speed;
            slider.value = Mathf.MoveTowards(startHealth, targetHealth, timeScale);
        }
        lerpingHealth = false;
       // yield return slider.value;
    }


}
