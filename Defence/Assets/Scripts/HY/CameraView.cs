using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    // Start is called before the first frame update
    CameraLocation currentLocation;

    /*void Start()
    {
        currentLocation = CameraLocation.BG_Lock;
        // 모든 화면들 z축 옮긴 위치에 카메라 생성
        // static?
        // 화면마다 카메라 위치 기억해놓고 
        // 옮길 때마다 어느 화면인지 그 화면 위치로 확인 
    }
    */

    // 

    public enum CameraLocation // 메인 카메라 위치
    {
        BG_Lock = 0, // 처음 화면
        BG_Lock_Drawer = 1, // 처음 화면 - 서랍
        BG_Lock_Closet = 2, // 처음 화면 - 옷장
        BG_Bed = 3, // 침실
        BG_UndertheBed = 4, // 침대 아래
        BG_Lamp = 5, // 램프 있는 방
        BG_Lamp_ToyBox = 6, // 장난감 상자
        BG_Lamp_Lamp = 7, // 램프
        BG_Lamp_Drawer = 8, // 서랍
        BG_Lamp_Window = 9, // 창문
        BG_Door = 10, // 문 있는 방
        BG_Door_Door = 11, // 문 있는 방
    }

    
}
