using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevels : MonoBehaviour
{
    public GameObject LeftArrow;
    public GameObject RightArrow;

    public GameObject FirstLevel;
    public GameObject SecondLevel;
    public void Left()
    {
        if (SecondLevel.activeSelf)
        {
            LeftArrow.SetActive(false);
            RightArrow.SetActive(true);
            FirstLevel.SetActive(true);
            SecondLevel.SetActive(false);
        }
    }
    public void Right()
    {
        if (FirstLevel.activeSelf)
        {
            LeftArrow.SetActive(true);
            RightArrow.SetActive(false);
            FirstLevel.SetActive(false);
            SecondLevel.SetActive(true);
        }
    }
}
