using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && this.GetComponent<ControlLight>().HandLight.activeSelf)
        {
            isObj();//오브젝트 인지 체크
        }
    }

    void isObj()
    {
        hit = this.GetComponent<RayCast>().getHit;
        if (hit && this.gameObject.GetComponent<ControlLight>().HandLight.activeSelf)
        {//손전등이 켜져있을 때
            //Debug.Log("if 들어옴");
            if (hit.transform.GetComponent<SelectObject>())
            {
                //Debug.Log(hit.transform.GetComponent<SelectObject>().obj.objectType);
                hit.transform.GetComponent<SelectObject>().ObjBtn.SetActive(true);
            }
            else
            {
                //hit.transform.GetComponent<SelectObject>().ObjBtn.SetActive(false);
                Debug.Log("아무것도 눌러지지 않음");
                //HideAllBtn();
            }
        }
    }

}
