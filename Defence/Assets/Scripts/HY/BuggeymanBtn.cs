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
    
    void Start()
    {
        buggey = GameObject.FindGameObjectWithTag("Buggey");// 부기맨 겜오브젝 갖고오기
        //buggey.gameObject.SetActive(false);
        // 랜덤 생성 : 50퍼센트 확률로 나오게
    }

    void Update()
    {

    }

    public void BuggeyAppear()
    {
        // 버튼 누르면 부기맨 켜기
        buggey.gameObject.SetActive(true);
    }
}
