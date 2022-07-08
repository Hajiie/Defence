using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuggeymanBtn : MonoBehaviour
{
    public GameObject buggey;
    public CameraView cameraview;

    private bool IsExistBuggey;

    // 10초 테스트

    // 화면 전환됐을 때, 어떤 확률로 등장하는 지만 구현되어 있음
    // Door_Door 10초 이내 구현 필요
    //시간초 필요할 때만 돌려 / 옷장, 책상, 침대 밑, 문
    // 0되면 멈춤


    public bool IsBuggey
    {
        get { return IsExistBuggey; }
    }

    public void BuggeyOffBtn()
    {
        buggey.SetActive(false);
    }


    public void BuggeyAppearCloset() // 옷장 클로징 + 오픈 후
    {
        BuggeyAppear(50); // 첫 오픈
        // 첫번재 오픈이랑 나머지를 어케 구분해야되지>
        // 120초 지나면 0.3으로 출현
        // 150초 지나면 0.5로 출현
        // 180초 지나면 1.0z
    }


    public void BuggeyAppearDrawer() // 서랍 클로징 후
    {
        IsExistBuggey=BuggeyAppear(40);
    }

    public void BuggeyAppearUndertheBed() // 침대 밑
    {
        IsExistBuggey = BuggeyAppear(40);
    }

    public void BuggeyAppearDoor_Door() // 문 클로징 후 / 침대에서 Hide 누르기 전까지 모든 화면에서 등장할 수 있음
    {
        //Debug.Log((int)time_current);

        if (cameraview.time_max <= 10) // 10초 이내면 - 이거 그냥 10초 이내에 랜덤 등장
        {
            BuggeyAppear(50);
        }
        else // 10초 지나면
            buggey.SetActive(true); // 게임 오버
        // Door_Door : 10초 이내 - 6초에 50% 10초에 100% 등장
        // 10초 지나면 등장
        // 6초 지나면 50퍼센트 확률
    }

    public bool BuggeyAppear(int num) // 부기맨 등장 함수(확률)
    {
        int xcount = Random.Range(1, 101); // 1 ~ 100에서 하나 뽑은거
        // random 값이 1~10 나오면 10%
        for (int i = 1; i != xcount; i++) // 1 ~ 100까지 돌리기 / i값과 뽑은 값이 같으면 멈추기

            if (xcount >= 0 && xcount < num)
            {
                buggey.SetActive(true);
                return true;
                // 게임오버
                //Debug.Log(xcount);
            }
            // xcount 값이 해당 범위 안에 있으면
            else
            {
                //Debug.Log(xcount);
                return false;
            }

        return false;
    }
}
