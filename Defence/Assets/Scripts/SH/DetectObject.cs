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
        isObj();
    }

    void isObj()
    {
        hit = this.GetComponent<RayCast>().getHit;
        if (hit)
        {
            if (hit.transform.GetComponent<SelectObject>())
            {
                Debug.Log(hit.transform.GetComponent<SelectObject>().obj.objectType);
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
