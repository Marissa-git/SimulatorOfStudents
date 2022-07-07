using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionWriteOffButtonScript : MonoBehaviour
{
    public GameObject GoodCanvas;
    public GameObject BadCanvas;
    public void ShowNextCanvas()
    {
        int fortune = GameObject.Find("Player").GetComponent<PlayersScrypt>().currentFortune;
        var rand = new System.Random();
        
        if (rand.Next(10) < fortune)
            GoodCanvas.SetActive(true);
        else
            BadCanvas.SetActive(true);
    }
}
