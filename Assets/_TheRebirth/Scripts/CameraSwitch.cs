using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cameraEnter;


    private void Start()
    {
       // mainCamera = Camera.main;
        mainCamera.enabled = true;
        cameraEnter.enabled = false;
    }

    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {


        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Test Works");
            cameraEnter.enabled = true;
            mainCamera.enabled = false;

        }
        
    }
}
