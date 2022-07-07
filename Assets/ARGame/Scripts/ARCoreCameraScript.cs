using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class ARCoreCameraScript : MonoBehaviour
{
   // public GameObject Dormitory;
    

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
         void OnCollisionEnter(Collision other)
        {
            //  Dormitory.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
   
}
