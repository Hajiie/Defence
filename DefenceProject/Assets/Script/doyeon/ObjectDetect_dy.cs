using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ObjectDetect_dy : MonoBehaviour
{
    RaycastHit2D hit;
    Vector3 raycastDir = new Vector3(0, 0, 5);
    Vector3 mousePos, realmousePos, transPos, targetPos;
    [SerializeField] Camera mainCamera;
    [SerializeField] float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //CheckConflict();
            MoveFlashLight();
        }
    }
    void CheckConflict()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(mousePos, new Vector3(0, 0, 10), Color.red, 1.5f); 
        hit = Physics2D.Raycast(mousePos, raycastDir, 10f);
        if(hit && hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Debug.Log(mousePos);
        }
    }
    void MoveFlashLight()
    {
        realmousePos = Input.mousePosition;
        Debug.Log(realmousePos);
        transPos = Camera.main.ScreenToWorldPoint(realmousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);
        Debug.Log(targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }
}
