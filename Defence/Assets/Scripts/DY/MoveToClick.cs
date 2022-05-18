using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToClick : MonoBehaviour
{
    RaycastHit2D hit;
    Vector3 raycastDir = new Vector3(0, 0, 1);
    Vector3 mousePos, transPos, targetPos;
    public GameObject cabinetBtn, closetBtn;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CallTargetPos();
        }
    }
    void CallTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos + new Vector3(10, 10, 10));
        Debug.Log(transPos);
        targetPos = new Vector3((transPos.x + 0.001f), (transPos.y + 0.001f), 0);
        transform.position = targetPos;
        //Debug.DrawRay(transform.position, new Vector3(0, 0, 10), Color.red, 1f);
        hit = Physics2D.Raycast(transform.position, raycastDir, 5f);

        if (hit)
        {
            Debug.Log(hit.collider.tag);
            ShowBtn();
        }
        else
        {
            Debug.Log("아무것도 눌러지지 않음");
            HideAllBtn();
        }
    }

    void ShowBtn()
    {
        cabinetBtn.SetActive(false);
        closetBtn.SetActive(false);
        if (hit.collider.tag == "Cabinet")
        {
            cabinetBtn.SetActive(true);
        }
        else if (hit.collider.tag == "Closet")
        {
            closetBtn.SetActive(true);
        }
    }
    void HideAllBtn()
    {
        cabinetBtn.SetActive(false);
        closetBtn.SetActive(false);
    }
}
