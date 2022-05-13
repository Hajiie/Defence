using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObj : MonoBehaviour
{
    RaycastHit2D hit;
    Vector3 raycastDir = new Vector3(0, 0, 1);
    Vector3 mousePos;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckConflict();
        }
    }
    void CheckConflict()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(1, 1, 1);
        Debug.Log(mousePos);
        Debug.DrawRay(mousePos, new Vector3(0, 0, 10), Color.red, 0.5f); 
        hit = Physics2D.Raycast(mousePos, raycastDir, 15f);

        if(hit)
        {
            Debug.Log(hit.collider.name);
        }
    }
}
