using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLight : MonoBehaviour
{
    RaycastHit2D hit;
    public Camera mainCamera;
    public GameObject HandLight;
    Vector3 transPos, targetPos;
    // Start is called before the first frame update
    void Start()
    {
        //HandLight = GameObject.Find("HandLight");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsDrag();
        }
    }

    void IsDrag()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//카메라 기준 마우스 좌표
        //hit = Physics2D.Raycast(ray.origin, ray.direction);//선택한 오브젝트 = hit
        transPos = mainCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(10, 10, 10));
        targetPos = new Vector3((transPos.x + 0.001f), (transPos.y + 0.001f), 0);
        HandLight.transform.position = targetPos;
    }
    public void SetLight()
    {
        if (HandLight.activeSelf == true && this.GetComponent<Inventory>().BatteryNum <= 0)
        {
            HandLight.SetActive(false);
            this.GetComponent<Battery>().LightON();
        }
        else if (HandLight.activeSelf == false)
        {
            HandLight.SetActive(true);
            this.GetComponent<Battery>().LightON();
        }
    }

    public void LightOff()
    {
        HandLight.SetActive(false);
    }
}
