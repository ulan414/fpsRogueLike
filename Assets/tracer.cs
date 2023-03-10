using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracer : MonoBehaviour
{
    Vector3 lastPos;

    /*public bool destroy = false;*/
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawLine(lastPos, transform.position);
        if (Physics.Linecast(lastPos, transform.position, out hit))
        {

            /*gameObject.transform.localPosition = new Vector3(0, 0, 0);*/

            Destroy(gameObject);
        }
        lastPos = transform.position;
    }
}
