using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CustomCameraControl : MonoBehaviour
{
    public CinemachineFreeLook freeLookCam;
    public float xSensitivity = 50f;
    public float ySensitivity = 1f;

    void Update()
    {
        if (CutsceneManager.Instance.isCutscenePlaying)
        {
            freeLookCam.m_XAxis.m_InputAxisName = ""; 
            freeLookCam.m_YAxis.m_InputAxisName = "";
        }
        else 
        {
            freeLookCam.m_XAxis.m_InputAxisName = "Mouse X"; // Restore input
            freeLookCam.m_YAxis.m_InputAxisName = "Mouse Y";

            float mouseX = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;

            freeLookCam.m_XAxis.Value += mouseX;
            freeLookCam.m_YAxis.Value -= mouseY;
        }
        
    }
}
