using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public Transform target; // 카메라 위치
    public Vector3 offset; // 이동할 위치
   
    public GameObject DownArrow;
    public GameObject UpArrow;
    public GameObject LeftRightArrow;

    float location_x;
    float location_y;

    bool downArrow; // 켜짐 유무
    bool leftrightArrow;

    void Update()
    {
        // 태그 넣어서 .... ..
        // 다시 침실로 돌아왔을 때는 꺼져야함
        location_x = target.position.x;
        location_y = target.position.y;
        // 꺼진거면 켜지게 ! 해야겠다 <<<
        // 변수에 대입 해줘야함 - 아직 아무것도 안 넣어준 상태

        if (location_x == -20 && location_y == 5) // 침실이면 아래 화살표만
        {
            UpArrow.SetActive(false); // 위 화살표는 기본적으로 꺼주기
            DownArrow.SetActive(true);
            leftrightArrow = true; 

            if (!leftrightArrow)// 아래 + 양 옆 꺼져있으면 켜주기
            { 
                //DownArrow.SetActive(true);
                ArrowAppear(true);
            }  
        }

        else if(location_x == -20 && location_y == 20) // 침대 아래면 위 화살표만
        {
            UpArrow.SetActive(true); // 기본적으로 켜주기
            DownArrow.SetActive(false);
            if (leftrightArrow) // 양 옆 + 아래 화살표 둘 중 하나라도 켜져있으면
            {
                ArrowAppear(false);
            }
        }
        else
        {
            UpArrow.SetActive(false);
            DownArrow.SetActive(false);
            ArrowAppear(true);
        }
    }

    public void cameraMoveLeft() // 카메라 위치를 '정해진 위치'로 바꿔주어야함
    {
        // 왼쪽 버튼 누를 때마다 x축 좌표 -20씩
        // -60이면 0으로 이동

        //location_x = target.position.x;
        //location_y = target.position.y;

        Vector3 BG_Lock = new Vector3(0, location_y, -10);


        if (location_x <= 0 && location_x > -60)
           // 근데 이거 왜 이상이하 아님?ㅜ
        {
           Vector3 offset = new Vector3(location_x - 20, location_y, -10);
           // 왼쪽 이동
           target.transform.position = offset;      
        }
        else if (location_x == -60.0)
        {
           //Debug.Log(location_x);
           target.transform.position = BG_Lock;
        }
    }

    public void cameraMoveRight() // 카메라 위치를 '정해진 위치'로 바꿔주어야함
    {
        //location_x = target.position.x;
        //location_y = target.position.y;

        Vector3 BG_Door = new Vector3(-60, location_y, -10);

        if (location_x < 0 && location_x >= -60)
        {
            Vector3 offset = new Vector3(location_x + 20, location_y, -10);
            // 오른쪽 이동
            target.transform.position = offset;
        }
        else if (location_x == 0)

        {
            target.transform.position = BG_Door;
        }
    }

    public void cameraMoveUp()
    {
        Vector3 offset = new Vector3(location_x, location_y - 15, -10);
        target.transform.position = offset;
    }

    public void cameraMoveDown()
    {
        Vector3 offset = new Vector3(location_x, location_y + 15, -10);
        target.transform.position = offset;
    }

    public void ArrowAppear(bool leftrightArrow) // true면 켜짐
    { 
    
        //Debug.Log(a);
        LeftRightArrow = GameObject.FindWithTag("Arrow");
        LeftRightArrow.SetActive(leftrightArrow);
        //null이 왜 뜰 까요,, ㅜㅜ
    }
}