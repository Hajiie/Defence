using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public Transform target; // 카메라 위치
    public Vector3 offset; // 이동할 위치

    float location_x;
    float location_y;

    void Update()
    {

    }

    public void cameraMoveLeft() // 카메라 위치를 '정해진 위치'로 바꿔주어야함
    {
        // 왼쪽 버튼 누를 때마다 x축 좌표 -20씩
        // -60이면 0으로 이동

        location_x = target.position.x;
        location_y = target.position.y;

        Vector3 BG_Lock = new Vector3(0, location_y, -10);


        if (location_x <= 0 && location_x > -60)
           // 근데 이거 왜 이상이하 아님?ㅜ
        {
           Vector3 offset = new Vector3(location_x - 20, location_y, -10);
           // 왼쪽 이동
           target.transform.position = offset;
           //Debug.Log(offset);       
        }
        else if (location_x == -60.0)

        {
           //Debug.Log(location_x);
           target.transform.position = BG_Lock;
        }

    }

    public void cameraMoveRight() // 카메라 위치를 '정해진 위치'로 바꿔주어야함
    {
        location_x = target.position.x;
        location_y = target.position.y;

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
        // 침대 아래 장면에서만 뜸
    }

    public void cameraMoveDown()
    {
        // 침대 씬에서 + 침대 아래 장면에서 뜸
    }
}