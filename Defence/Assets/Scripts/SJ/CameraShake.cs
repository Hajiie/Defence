using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //조준 할 때 떨림

    public Camera mainCamera;
    Vector3 cameraPos;

    [SerializeField] [Range(0.01f, 0.1f)] float shakeRange = 0.05f;
    [SerializeField] [Range(0.1f, 1f)] float duration = 0.5f;

    public void shake()
    {
        cameraPos = mainCamera.transform.position;
        InvokeRepeating("StartShaking", 0f, 0.005f);
        Invoke("StopShake", duration);
    }

    public void StartShaking()
    {
        float cameraPosX = Random.value * shakeRange * 2 - shakeRange;
        float cameraPosY = Random.value * shakeRange * 2 - shakeRange;
        cameraPos.x += cameraPosX;
        cameraPos.y += cameraPosY;
        mainCamera.transform.position = cameraPos;
    }

    public void StopShaking()
    {
        CancelInvoke("StartShaking");
        mainCamera.transform.position = cameraPos;
    }
}
