using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject cameraFPS;
    public GameObject cameraFreeView;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            cameraFPS.SetActive(true);
            cameraFreeView.SetActive(false);
        }
        
        else if (Input.GetKey("2"))
        {
            cameraFPS.SetActive(false);
            cameraFreeView.SetActive(true);
        }
    }
}
