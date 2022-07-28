using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2_Animation : MonoBehaviour
{
    // 스프라이트 렌더러
    // 시작하자마자 재생
    // 일정 시간 지나면 스프라이트 교체

    public Sprite[] images;
    public SpriteRenderer spriterenderer;
    //loat time_max = 5f;
    int i = 0;

    public void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        //spriterenderer.sprite = images[0];
        StartCoroutine(countTime());

    }

    IEnumerator countTime()
    {
        for(int i = 0; i<=5; i++) // 1이상 6이하일 때                     // 이미지가 sprite[5] 이상일 경우 멈추기)
        {
                
                yield return new WaitForSeconds(1.5f); // 5초 기다렸다 실행
                spriterenderer.sprite = images[i + 1];
                StartCoroutine(countTime());
        }
    
    }
    // 어떻게 멈추죠ㅇㅅㅇ
}