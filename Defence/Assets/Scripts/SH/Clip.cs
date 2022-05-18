using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clip : MonoBehaviour
{
    int clip_num;
    Inventory Inven;
    public Text cliptext;
    // Start is called before the first frame update
    void Start()
    {
        clip_num = 0;
        Inven = this.GetComponent<Inventory>();//인벤토리 설정
    }

    // Update is called once per frame
    void Update()
    {
        cliptext.text = "X" + clip_num;//Text 출력
        IsClipGet();
    }

    void IsClipGet()
    {
        if (clip_num < Inven.ClipNum)//현재 가지고 있는 클립과 비교 시 인벤토리에 클립이 늘었을 시
        {
            clip_num = Inven.ClipNum;//새롭게 초기화
            print(clip_num);
        }
    }
}
