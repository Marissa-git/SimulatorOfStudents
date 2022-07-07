using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionButtonsBehaviorScript : MonoBehaviour
{
    public GameObject NextCanvas;
    public void ShowNextCanvas()
    {
        NextCanvas.SetActive(true);
    }
}
