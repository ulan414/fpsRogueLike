using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSniper : MonoBehaviour
{
    private float rotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 rotation = new Vector3(0f, 195f, 0f);
        transform.Rotate(rotation, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
/*        Vector3 desiredRotation = new Vector3(0f, 45f, 0f);
        transform.rotation = Quaternion.Euler(desiredRotation);*/
    }
}
