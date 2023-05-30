/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.01f;
    public float laserMaxLength = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if(dying)
            laserLineRenderer.enabled = false;
    }
    void ShootLazer()
    {
        if (elapsed >= LastShootTimeFirstPart)
        {
            ShootLaserFromTargetPosition(shotPoint.transform.position, directionCor, fireRadius);
            Ray raySeePlayerM4Laser = new Ray();
            raySeePlayerM4Laser.origin = shotPoint.transform.position;
            raySeePlayerM4Laser.direction = shotPoint.forward;
            //Debug.DrawRay(raySeePlayerM4Laser.origin, raySeePlayerM4Laser.direction * 100f, Color.green);
            RaycastHit hitLaser;
            if (Physics.Raycast(raySeePlayerM4Laser, out hitLaser))
            {
                playerPositionWhenShoot = hitLaser.point;
                //Debug.Log(playerPositionWhenShoot);
                Shoot.setPlayerPosition(playerPositionWhenShoot);
            }
            laserLineRenderer.enabled = true;
            mustShoot = true;
            directionCorMust = directionCor;
            directionCorMust1 = directionCor1;

            //Shoot.setPlayerPosition(directionCorMust);
            lastLaserTime = Time.time;
        }
    }
    void DisableLazer()
    {
        gameObject.GetComponent<Animator>().SetBool("run_back", false);
        gameObject.GetComponent<Animator>().SetBool("Fire", false);
        gameObject.GetComponent<Animator>().SetBool("idle", true);
        laserLineRenderer.enabled = false;
    }
    void Rotate(Vector3 directionCor)
    {

        if (directionCor == Vector3.zero)
            return;

        Quaternion rotation = Quaternion.LookRotation(directionCor);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}
*/