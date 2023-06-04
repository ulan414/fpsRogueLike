using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public int money = 3000;
    [SerializeField] private TMPro.TextMeshProUGUI BalanceText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateBalance();
    }
    public void UpdateBalance()
    {
        BalanceText.text = money.ToString() + "$";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
