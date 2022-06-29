using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int battery_num = 2;
    private int clip_num = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int BatteryNum//배터리 갯수 제어
    {
        get { return battery_num; }//배터리 갯수 리턴
        set
        {
            switch (value)//1의 값이면 배터리 get, -1의 값이면 배터리 use
            {
                case 1:
                    battery_num = 4;
                    break;
                case -1:
                    battery_num -= 1;
                    break;
                default:
                    break;
            }
        }
    }


    public int ClipNum//클립의 갯수 return
    {
        get { return clip_num; }
        set
        {
            switch (value)//1의 값이면 클립 get, -1의 값이면 클립 use
            {
                case 1:
                    clip_num += 1;
                    break;
                case -1:
                    clip_num -= 1;
                    break;
                default:
                    break;
            }
        }
    }


}
