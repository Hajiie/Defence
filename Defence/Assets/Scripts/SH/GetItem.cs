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
            print(hit.point);
            hit = this.GetComponent<RayCast>().getHit;
            if (hit)
            {
                if (hit.transform.GetComponent<SelectItem>())//<SelectItem> 존재 유무
                {

                    print(hit.transform.GetComponent<SelectItem>().item.itemType.ToString());
                    switch (hit.transform.GetComponent<SelectItem>().item.itemType)
                    {
                        case Item.ItemType.Battery:
                            this.GetComponent<Inventory>().BatteryNum = 1;
                            break;
                        case Item.ItemType.Clip:
                            this.GetComponent<Inventory>().ClipNum = 1;
                            break;
                        default:
                            break;
                    }
                }
            }
            //Debug.DrawRay(ray.origin, ray.direction, Color.black, 5.0f, true);
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
