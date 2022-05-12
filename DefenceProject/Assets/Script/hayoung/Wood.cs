using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour
{
    // 시간 지남에 따라 나무 이미지 변화
    // 0초, 90초, 120초. max : 180초
    // 시간을 정수값으로 받고, 정수값

    private float time_current;
    private float time_max = 10f;

    GameObject wood;
    public Image basicImage;
    public Sprite[] img;
    //public SpriteRenderer spriteRenderer;

    void Start()
    {
        //isEnded = true;
        wood = FindObjectOfType<GameObject>();
        basicImage = wood.GetComponent<Image>();
        reset_time();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (time_max > 0)
            time_max -= Time.deltaTime;
        else
            return;
        // 0되면 멈춤
        time();
        //180초 타이머
    }

    public void time()
    {
        // 처음 시작은 이미지1이어야함

        time_current = time_max;
      
        //Debug.Log(time_current);

        if (time_current <= 8) // 90초 지났을 때
        {
            Debug.Log(time_current);
            basicImage.sprite = img[1];

        }
        else if (time_current <= 4)
        {
            wood.GetComponent<Image>().sprite = img[2];
        }
        /*else if (time_current == 0)
        {
            //spriteRenderer.sprite = img[0];
            //게임오버
            return;
        }
        */     
    }

    private void reset_time() //시간 초기화
    {
        time_current = time_max;
    }
}
