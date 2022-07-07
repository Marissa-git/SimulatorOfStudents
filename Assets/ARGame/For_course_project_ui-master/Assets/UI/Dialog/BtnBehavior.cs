using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnBehavior : MonoBehaviour
{
    public GameObject canvas;
    public void HideCanvas()
    {
        canvas.SetActive(false);
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
