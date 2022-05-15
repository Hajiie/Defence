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
        cliptext.text = "X" + clip_num;
        IsClipGet();
    }

    void IsClipGet()
    {
        if (clip_num < Inven.GetClipNum())
        {
            clip_num = Inven.GetClipNum();
            print(clip_num);
        }
    }
}
