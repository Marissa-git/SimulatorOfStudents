using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyAmountScript : MonoBehaviour
{
    public Text txt;
    public void SetMoneyAmount(string amount)
    {
        txt.text = amount;
    }
}
