using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuggeymanBtn : MonoBehaviour
{
    public GameObject buggey;
    public CameraView cameraview;
    private float time_current;
    private float time_max = 10f; // 10초 테스트


   void Update()
    { // 시간초 필요할 때만 돌려 / 옷장, 책상, 침대 밑, 문
        /*if (CameraView.currentImgLocation == (int)CameraView.CameraLocation.BG_Door_Door) // BG_Door_Door이면
        {
            if (time_max > 0)
                time_max -= Time.deltaTime;
            else
                return;
        }
        */
        // 0되면 멈춤
    }


    public void BuggeyAppearCloset() // 옷장 클로징 + 오픈 후
    {
        BuggeyAppear((int)CameraView.CameraLocation.BG_Lock_Closet, 50); // 첫 오픈
        // 120초 지나면 0.3으로 출현
        // 150초 지나면 0.5로 출현
        // 180초 지나면 1.0
    }


    public void BuggeyAppearDrawer() // 서랍 클로징 후
    {
        BuggeyAppear((int)CameraView.CameraLocation.BG_Lamp_Drawer, 40);
    }

    public void BuggeyAppearUndertheBed() // 침대 밑
    {
        BuggeyAppear((int)CameraView.CameraLocation.BG_UndertheBed,40);
    }

    public void BuggeyAppearDoor_Door() // 문 클로징 후 / 침대에서 Hide 누르기 전까지 모든 화면에서 등장할 수 있음
    {
        time_current = time_max;
        //Debug.Log((int)time_current);

        if (time_max <= 10) // 10초 이내면 - 이거 그냥 10초 이내에 랜덤 등장
        {
            BuggeyAppear((int)CameraView.CameraLocation.BG_Lock,50);
        }
        else // 10초 지나면
            buggey.SetActive(true); // 게임 오버
        // Door_Door : 10초 이내 - 6초에 50% 10초에 100% 등장
        // 10초 지나면 등장
        // 6초 지나면 50퍼센트 확률
    }

    public void BuggeyAppear(int currentlocation, int num) // 부기맨 등장 함수(확률)
    {
        int xcount = Random.Range(1, 101); // 1 ~ 100에서 하나 뽑은거
        // random 값이 1~10 나오면 10%
        for (int i = 1; i != xcount; i++) // 1 ~ 100까지 돌리기 / i값과 뽑은 값이 같으면 멈추기
        //Debug.Log(xcount);

        if (xcount >= 0 && xcount < num) // xcount 값이 해당 범위 안에 있으면
             buggey.SetActive(true);
        else
           return;
    }
}
