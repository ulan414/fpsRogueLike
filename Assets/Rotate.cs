using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Vector3 rotateDirec = new Vector3(0, 0, 0);
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotates(rotateDirec);
    }
    void Rotates(Vector3 directionCor)
    {

        if (directionCor == Vector3.zero)
            return;

        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
    }
    public void SetDirection(Vector3 dir)
    {
        rotateDirec = dir;
    }
}
