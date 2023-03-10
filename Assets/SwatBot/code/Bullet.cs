using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Speed;
    Vector3 lastPos;
    public GameObject decal;
    public MeshRenderer PLS;

    /*public bool destroy = false;*/
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        RaycastHit hit;
        Debug.DrawLine(lastPos, transform.position);
        if(Physics.Linecast(lastPos, transform.position, out hit))
        {
            GameObject d = Instantiate<GameObject>(decal);
            d.transform.position = hit.point + hit.normal * 0.01f;
            d.transform.rotation = Quaternion.LookRotation(-hit.normal);
            Destroy(d, 10);

            /*gameObject.transform.localPosition = new Vector3(0, 0, 0);*/

            Destroy(gameObject);
        }
        lastPos = transform.position;    
    }
}
