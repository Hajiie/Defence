using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLight : MonoBehaviour
{
    RaycastHit2D hit;
    public GameObject HandLight;
    // Start is called before the first frame update
    void Start()
    {
        //HandLight = GameObject.Find("HandLight");
    }

    // Update is called once per frame
    void Update()
    {
        IsDrag();
    }

    void IsDrag()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//카메라 기준 마우스 좌표
        //hit = Physics2D.Raycast(ray.origin, ray.direction);//선택한 오브젝트 = hit
        HandLight.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        HandLight.transform.position = new Vector3(HandLight.transform.position.x, HandLight.transform.position.y, 0);
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
