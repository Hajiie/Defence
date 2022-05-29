using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuggeymanBtn : MonoBehaviour
{

    // 버튼 눌렀을 때 부기맨 등장
    // 랜덤 확률로 ("아무 것도 나타나지 않았다.")
    // 등장하고 확대되는 애니메이션

    public GameObject buggey;
    public bool buggeyOn;

    void Update()
    {

    }

    // Door_Door : 10초 이내 - 6초에 50% 10초에 100% 등장


    public void BuggeyAppear()
    {
        // 그냥 bool 만들어서 껐다 켜는 거 해준 거
        if (buggeyOn)  // 켜진 상태
        {
            buggeyOn = false;
            buggey.gameObject.SetActive(false);
        }

        else if (!buggeyOn) //꺼진 상태
        {
            buggeyOn = true;
            buggey.gameObject.SetActive(true);
        }
       
    }
}
