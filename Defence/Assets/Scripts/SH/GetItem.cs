using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    RaycastHit2D hit;
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
            hit = Physics2D.Raycast(ray.origin, ray.direction);//선택한 오브젝트 = hit
            print(hit.point);
            if (hit)
            {
                if (hit.transform.GetComponent<SelectItem>())//<SelectItem> 존재 유무
                {

                    print(hit.transform.GetComponent<SelectItem>().item.itemType.ToString());
                    if (hit.transform.GetComponent<SelectItem>().item.itemType == Item.ItemType.Battery)
                    {
                        this.GetComponent<Inventory>().GetBattery();
                    }
                    if (hit.transform.GetComponent<SelectItem>().item.itemType == Item.ItemType.Clip)
                    {
                        this.GetComponent<Inventory>().GetClip();
                        print(this.GetComponent<Inventory>().GetClipNum());
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction, Color.black, 5.0f, true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (hit)
            {
                if (hit.transform.GetComponent<SelectItem>())
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
