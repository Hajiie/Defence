using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight_dy : MonoBehaviour
{
    Vector3 mousePos, transPos, targetPos;
    [SerializeField] Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CallTargetPos();
        }
        MovetoTargetPos();
    }
    void CallTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = mainCamera.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);
    }
    void MovetoTargetPos()
    {
        transform.position = targetPos;
    }
}
