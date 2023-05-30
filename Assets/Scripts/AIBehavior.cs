/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform Player1;
    UnityEngine.AI.NavMeshAgent nav;
    public bool dying = false;
    public float dist;
    float elapsed = 0f;
    float elapsedFirstPart = 0f;

    public float radius = 35;
    public float fireRadius = 25;
    public float run_back = 2;

    bool firstshoot = true;
    bool hasSeenPlayer;
    float lastShootingTime = 0f;
    bool isShooting = false;
    bool needToMove = false;
    float needToMoveTime = 0f;
    float rotationSpeed = 14f;
    float countEven = 0;
    [SerializeField]
    public TrailRenderer BulletTrailFirstPart;
    [SerializeField]
    public ParticleSystem shootingSystem;

    public Transform shotPoint;
    public Transform seePlayer;
    public TrailRenderer bulletTrailFirstPart;

    public float rotateAngle = 0f;
    private int ammunitionCurrent;
    public shoot Shoot;
    public Rotate rotateCs;

    public bool dead = false;
    bool mustShoot = false;
    bool isReloading = false;
    //Bots
    public bool sniper = false;
    Vector3 directionCor = new Vector3(0, 0, 0);
    Vector3 directionCor1 = new Vector3(0, 0, 0);
    Vector3 directionCorMust = new Vector3(0, 0, 0);
    Vector3 directionCorMust1 = new Vector3(0, 0, 0);
    Vector3 playerPositionWhenShoot = new Vector3(0, 0, 0);
    float lastLaserTime = 0f;
    bool playones = false;
    Vector3 Player = new Vector3(0, 0, 0);

    public LineRenderer laserLineRenderer;
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Player1 = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (dying)
        {
            Dying();
            return;
        }
        Vector3 Player = Player1.position;
        dist = Vector3.Distance(Player, transform.position);
        if (dist > radius)
        {
            Idle();
        }
        else if (dist < radius && dist > fireRadius)
        {
            //run to player
        }
        else if (dist < fireRadius) //&& dist > run_back
        {
            if (needToMove && Time.time - needToMoveTime > 0.3f)
            {
                needToMove = false;
            }
            if (mustShoot && Time.time - lastLaserTime > 1.5f)
            {
                mustShoot = false;
                laserLineRenderer.enabled = false;
            }
            gameObject.GetComponent<Animator>().SetBool("run", false);
            isReloading = false;
            if (Shoot.ammunitionCurrent != Shoot.Ammo && Shoot.ammunitionCurrent < 1 && Shoot.ammunitionTotal != 0)
            {
                Shoot.Reload();
                lastShootingTime = Time.time;
                isReloading = true;
            }
            if (!mustShoot)
            {
                directionCor = (Player - seePlayer.transform.position + new Vector3(0, 1.7f, 0)).normalized;
                //rotate character
                directionCor1 = (Quaternion.AngleAxis(rotateAngle, transform.up) * (Player - seePlayer.transform.position + new Vector3(0, 1.1f, 0))).normalized;
            }
            else
            {
                directionCor = directionCorMust;
                directionCor1 = directionCorMust1;
            }
            Rotate(directionCor1);
            if (dist < run_back)
            {
                RunBackFromPlayer();
                return;
            }
            gameObject.GetComponent<Animator>().SetBool("run_back", false);
            gameObject.GetComponent<Animator>().SetBool("run", false);
            gameObject.GetComponent<Animator>().SetBool("idle", false);
            Ray raySeePlayer = new Ray();
            raySeePlayer.origin = seePlayer.transform.position;
            raySeePlayer.direction = directionCor;
            RaycastHit hit;
            if (Physics.Raycast(raySeePlayer, out hit))
            {
                Shooting();
            }
            else if (mustShoot)
            {
                elapsed += Time.deltaTime;
                if (elapsed >= shootingDelay)
                {
                    elapsed = elapsed % shootingDelay;
                    Shoot.shot();
                    mustShoot = false;
                    isShooting = true;
                    lastShootingTime = Time.time;
                    gameObject.GetComponent<Animator>().SetBool("run_back", false);
                    gameObject.GetComponent<Animator>().SetBool("Fire", false);
                    gameObject.GetComponent<Animator>().SetBool("idle", true);
                    laserLineRenderer.enabled = false;
                }
            }
        }
    }
    void Shooting()
    {
        if ((hit.collider.tag == "Player"))
        {
            nav.enabled = false;
            hasSeenPlayer = true;
            lastSeenTime = Time.time;

            gameObject.GetComponent<Animator>().SetBool("run_back", false);
            gameObject.GetComponent<Animator>().SetBool("run", false);
            gameObject.GetComponent<Animator>().SetBool("Fire", true);
            gameObject.GetComponent<Animator>().SetBool("idle", false);

            elapsed += Time.deltaTime;
            ShootLazer();
            if (elapsed >= shootingDelay)
            {
                elapsed = elapsed % shootingDelay;
                Ray raySeePlayerM4 = new Ray();
                raySeePlayerM4.origin = shotPoint.transform.position;
                raySeePlayerM4.direction = shotPoint.forward;
                RaycastHit hittt;
                if (Physics.Raycast(raySeePlayerM4, out hittt))
                {
                    if (hittt.collider.tag == "Player")
                    {
                        Shoot.shot();
                        mustShoot = false;
                        isShooting = true;
                        lastShootingTime = Time.time;
                        DisableLazer();
                    }
                    else
                    {
                        isShooting = false;
                    }
                }
            }
        }
        else if (mustShoot)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= shootingDelay)
            {
                elapsed = elapsed % shootingDelay;
                Shoot.shot();
                mustShoot = false;
                isShooting = true;
                lastShootingTime = Time.time;
                gameObject.GetComponent<Animator>().SetBool("run_back", false);
                gameObject.GetComponent<Animator>().SetBool("Fire", false);
                gameObject.GetComponent<Animator>().SetBool("idle", true);
                laserLineRenderer.enabled = false;
            }
        }
        else
        {
            if (!needToMove)
            {
                needToMove = true;
                needToMoveTime = Time.time;
            }
            isShooting = false;
            lastShootingTime = Time.time;
            if (Time.time - lastSeenTime > 10f && hasSeenPlayer)
            {
                hasSeenPlayer = false;
            }
            if (hasSeenPlayer && !mustShoot)
            {
                nav.enabled = true;
                nav.SetDestination(Player);
                gameObject.GetComponent<Animator>().SetBool("run_back", false);
                gameObject.GetComponent<Animator>().SetBool("Fire", false);
                gameObject.GetComponent<Animator>().SetBool("idle", false);
                gameObject.GetComponent<Animator>().SetBool("run", true);
            }
            else if (!hasSeenPlayer && !mustShoot)
            {
                gameObject.GetComponent<Animator>().SetBool("run_back", false);
                gameObject.GetComponent<Animator>().SetBool("run", false);
                gameObject.GetComponent<Animator>().SetBool("idle", true);
                nav.enabled = false;
            }
        }
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Firing_Rifle") && !isShooting && (Time.time - lastShootingTime > 2.3f) && lastShootingTime != 0f && !mustShoot)
        {
            needToMove = true;
            needToMoveTime = Time.time;
            nav.enabled = true;
            nav.SetDestination(Player);
            gameObject.GetComponent<Animator>().SetBool("run_back", false);
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            gameObject.GetComponent<Animator>().SetBool("idle", false);
            gameObject.GetComponent<Animator>().SetBool("run", true);
        }
    }

    void Idle()
    {
        nav.enabled = false;
        gameObject.GetComponent<Animator>().SetBool("run_back", false);
        gameObject.GetComponent<Animator>().SetBool("Fire", false);
        gameObject.GetComponent<Animator>().SetBool("run", false);
        gameObject.GetComponent<Animator>().SetBool("idle", true);
    }

    void RunBackFromPlayer()
    {
        if (!isReloading)
        {
            nav.enabled = true;
            Vector3 back_pos = new Vector3(5 * transform.position.x - 4 * Player.x, -0.2f, 5 * transform.position.z - 4 * Player.z);
            nav.SetDestination(back_pos);
            gameObject.GetComponent<Animator>().SetBool("run_back", true);
            gameObject.GetComponent<Animator>().SetBool("run", false);
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            gameObject.GetComponent<Animator>().SetBool("idle", false);
            gameObject.GetComponent<Animator>().SetBool("reloading", false);
        }
        else
        {
            nav.enabled = false;
        }
    }

    void Dying()
    {
        nav.enabled = false;
        gameObject.GetComponent<Animator>().SetBool("dying", true);
        gameObject.GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = false;
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        //gameObject.GetComponent<Collider>().enabled = false;
        var collidersObj = gameObject.GetComponentsInChildren<Collider>();
        for (var index = 0; index < collidersObj.Length; index++)
        {
            var colliderItem = collidersObj[index];
            colliderItem.enabled = false;
        }
        Destroy(gameObject, 7);
    }
}
*/