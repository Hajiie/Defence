using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject Goal;
    public static Vector2 StartPos;
    bool isInGoal;
    int bullNum = 0; // 2가 되면 다른 스크립트에서 단계 넘겨줄 예정..
    bool step1Check;
    bool step2Check;
    bool step3Check; // 장전 단계에 따라 보여질 오브젝트를 다른 스크립트에서 구현할 예정..

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
        if(isInGoal) 
        {
            if(Goal.transform.tag == "GoalArrow") 
            {
                transform.position = Goal.transform.position; // 목적지 화살표 위치로 이동
                Goal.SetActive(false); // 화살표 숨김
            }
            if (Goal.transform.tag == "Gun") // 총알 총에 넣는 경우
            {
                this.gameObject.SetActive(false); //총알 넣으면 그 총알 지움
                bullNum++;
            }
        }
        else // 목적지에 맞지 않으면 드래그 시작 지점으로 돌아감
        {
            transform.position = StartPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D target) // collider 충돌 판정
    {
        if (target.CompareTag("GoalArrow")) 
        {
            isInGoal = true;
        }
        if (target.CompareTag("Gun"))
        {
            isInGoal = true;
        }
    }
}