using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIProcedural : MonoBehaviour
{
   /* // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Player1 = GameObject.FindGameObjectWithTag("Player").transform;
        if (sniper)
        {
            Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
            laserLineRenderer.SetPositions(initLaserPositions);
            laserLineRenderer.SetWidth(laserWidth, laserWidth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Player = Player1.position;
        dist = Vector3.Distance(Player, transform.position);

        if(dist > fireRadius)
        {
            RunAfterPlayer();
        }
        else if(dist < fireRadius && dist >= run_back)
        {
            Fire();
        }
        else if(dist <= run_back)
        {
            //run back from player (too close)
            RunBack();
        }
    }
    void RunAfterPlayer()
    {
        nav.enabled = true;
        nav.SetDestination(Player1.transform.position);
        gameObject.GetComponent<Animator>().SetBool("run_back", false);
        gameObject.GetComponent<Animator>().SetBool("Fire", false);
        gameObject.GetComponent<Animator>().SetBool("idle", false);
        gameObject.GetComponent<Animator>().SetBool("run", true);
    }
    void Fire()
    {
        isReloading = false;
        if (Shoot.ammunitionCurrent != Shoot.Ammo && Shoot.ammunitionCurrent < 1 && Shoot.ammunitionTotal != 0)
        {
            Shoot.Reload();
            lastShootingTime = Time.time;
            isReloading = true;
        }

        Ray raySeePlayer = new Ray();
        raySeePlayer.origin = seePlayer.transform.position;
        raySeePlayer.direction = directionCor;
        RaycastHit hit;
        if (Physics.Raycast(raySeePlayer, out hit))
        {
            if ((hit.collider.tag == "Player"))
            {
                nav.enabled = false;
                gameObject.GetComponent<Animator>().SetBool("run_back", false);
                gameObject.GetComponent<Animator>().SetBool("run", false);
                gameObject.GetComponent<Animator>().SetBool("idle", false);
                gameObject.GetComponent<Animator>().SetBool("Fire", true);
            }
        }
    }*/
}
