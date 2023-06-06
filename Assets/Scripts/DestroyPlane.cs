using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DestroyPlane : MonoBehaviour
{
    // Update is called once per frame
    private GameObject Player;
    private GameObject PlaneGenerator;
    private PlaneGeneration planeGeneration;
    public int DestroyDistance = 80;

    [SerializeField] GameObject ammo;
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlaneGenerator = GameObject.Find("PlaneGenerator");
        planeGeneration = PlaneGenerator.GetComponent<PlaneGeneration>();
        StartCoroutine(OutputPositionEveryFiveSeconds());

        //instantiate ammo 10% chance
        Random random = new Random();
        int randomNumber = random.Next(100);
        if (randomNumber < 2)
        {
            GameObject instantiatedObject = Instantiate(ammo, transform.position + new Vector3(0, 0.25f, 0), transform.rotation);
            instantiatedObject.transform.localScale *= 0.2f;
            Camera cameraComponent = instantiatedObject.GetComponentInChildren<Camera>();
            if (cameraComponent != null)
            {
                Destroy(cameraComponent.gameObject);
            }
        }
    }
    private System.Collections.IEnumerator OutputPositionEveryFiveSeconds()
    {
        while (true)
        {
            // Output the position of the GameObject
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if(distance > DestroyDistance)
            {
                planeGeneration.removeTileFromHash(transform.position);
                Destroy(gameObject);
            }
            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);
        }
    }
}
