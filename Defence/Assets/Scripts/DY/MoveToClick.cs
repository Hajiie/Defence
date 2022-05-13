using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    RaycastHit2D hit;
    Vector3 raycastDir = new Vector3(0, 0, 1);
    Vector3 mousePos, transPos, targetPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CallTargetPos();
        }
        MoveToTargetandCheck();
    }
    void CallTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos + new Vector3(10, 10, 10));
        Debug.Log(transPos);
        targetPos = new Vector3((transPos.x+0.1f), (transPos.y+0.1f), 0);
        
        Debug.DrawRay(transform.position, new Vector3(0, 0, 10), Color.red, 1f);
        hit = Physics2D.Raycast(transform.position, raycastDir, 5f);

        if(hit)
        {
            Debug.Log(hit.collider.name);
        }
    }
    void MoveToTargetandCheck()
    {
        transform.position = targetPos;
    }
}
