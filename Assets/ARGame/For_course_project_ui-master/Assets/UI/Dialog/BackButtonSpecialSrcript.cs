using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonSpecialSrcript : MonoBehaviour
{
    public void DoNotCountDay()
    {
        GameObject.Find("Player").GetComponent<PlayersScrypt>().dayCounter--;
    }
}
