using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("P_LPSP_UI_Canvas(Clone)");
        if (obj != null)
        {
            // Disable the GameObject
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
