using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlane : MonoBehaviour
{
    // Update is called once per frame
    private GameObject Player;
    private GameObject PlaneGenerator;
    private PlaneGeneration planeGeneration;
    public int DestroyDistance = 80;
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlaneGenerator = GameObject.Find("PlaneGenerator");
        planeGeneration = PlaneGenerator.GetComponent<PlaneGeneration>();
        StartCoroutine(OutputPositionEveryFiveSeconds());
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
