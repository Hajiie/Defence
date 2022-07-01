using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public GameObject pointLight;
    public bool lightOn = false;

    public void SetLight()
    {
        if (lightOn)
        {
            pointLight.SetActive(false);
            lightOn = false;
        }
        else
        {
            pointLight.SetActive(true);
            lightOn = true;
        }
    }
    public void ShowTempMessage()
    {
        Debug.Log("연결된 씬으로 이동");
    }
}
