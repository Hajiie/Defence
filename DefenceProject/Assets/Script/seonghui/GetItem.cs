using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isTouch();
    }

    private void isTouch()
    {
        if (Input.GetMouseButtonDown(0))//Push Mouse Left
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//카메라 기준 마우스 클릭 좌표
            if (Physics.Raycast(ray, out hit))//선택한 오브젝트 = hit
            {
                //print(hit.transform.GetComponent<SelectItem>().item.itemName);
                if (hit.transform.GetComponent<SelectItem>())//<SelectItem> 존재 유무
                {
                    print(hit.transform.GetComponent<SelectItem>().item.itemType.ToString());
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (hit.transform.GetComponent<SelectItem>())
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
