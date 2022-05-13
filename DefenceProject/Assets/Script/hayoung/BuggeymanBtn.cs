using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuggeymanBtn : MonoBehaviour
{
    // 원래 setactive 써주지 않았나??

    // 버튼 눌렀을 때 부기맨 등장
    // 랜덤 확률로 ("아무 것도 나타나지 않았다.")
    // 등장하고 확대되는 애니메이션

    public GameObject buggey;

    void Start()
    {
        BuggeyDisappear();
        //BuggeyDisappear();// 부기맨 이미지 꺼놓기
        buggey = GameObject.Find("BuggeyMan"); // 부기맨 겜오브젝 갖고오기
        // 버튼 누르면 한 번만 나오니까 start문에 넣어야 될 듯
        // 랜덤 생성 : 50퍼센트 확률로 나오게
    }

    void Update()
    {
    }

    public void BuggeyAppear()
    {
        // 부기맨 등장했을 경우 - 부기맨 이미지 켜기
        //if
        buggey.gameObject.SetActive(true);
    }

    public void BuggeyDisappear()
    {
        buggey.gameObject.SetActive(false);
    }
}
