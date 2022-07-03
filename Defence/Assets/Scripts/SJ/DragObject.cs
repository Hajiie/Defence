using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject Goal;
    public static Vector2 StartPos;

    public void OnBeginDrag(PointerEventData eventData) 
    {
        StartPos = transform.position; // 드래그 시작할 때 오브젝트 위치 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.position == Goal.transform.position) // Goal.transform.position부분 판정때문에 수정해야함
        {
            if(Goal.transform.tag != "Gun") // 총은 총알 2발 장전하고나서
            {
                transform.position = Goal.transform.position;
                Goal.SetActive(false);
            }
            else
            {

            }
        }
        else // 목적지에 맞지 않으면 드래그 시작 지점으로 돌아감
        {
            transform.position = StartPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D target) // collider 충돌 판정. Goal.~ 부분 수정하는 것에 참고? 
    {

    }
}