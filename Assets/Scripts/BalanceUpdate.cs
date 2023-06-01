using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceUpdate : Balance
{
    [SerializeField] private TMPro.TextMeshProUGUI BalanceText;
    // Start is called before the first frame update
    void Start()
    {
        BalanceText.text = balance.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
