using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ObjectDetect_dy : MonoBehaviour
{
    RaycastHit hit;
    Vector3 raycastDir = new Vector3(0, 0, 1);
    [SerializeField] Camera mainCamera;
    //[SerializeField] float speed = 30f;
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
            CheckConflict();
            //MoveFlashLight();
        }
    }
    void CheckConflict()
    {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);    
        if(Physics.Raycast(mousePos, out hit) && hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Debug.Log(mousePos);
        }
    }
    void MoveFlashLight()
    {
        // realmousePos = Input.mousePosition;
        // Debug.Log(realmousePos);
        // transPos = Camera.main.ScreenToWorldPoint(realmousePos);
        // targetPos = new Vector3(transPos.x, transPos.y, 0);
        // Debug.Log(targetPos);
        // transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }
}
