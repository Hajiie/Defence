using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int battery_num = 2;
    private int Clip_num = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetBatteryNum()//배터리 갯수 return
    {
        return battery_num;
    }

    public void GetBattery()//배터리를 얻었을 시 +1
    {
        battery_num += 1;
    }

    public int UseBattery()//배터리 사용시 -1 & 리턴
    {
        battery_num -= 1;
        return battery_num;
    }

    public int GetClipNum()//클립의 갯수 return
    {
        return Clip_num;
    }

    public void GetClip()//클립을 얻었을 시 +1
    {
        Clip_num += 1;
    }

    public int UseClip()//클립 사용시 -1 & 리턴
    {
        Clip_num -= 1;
        return Clip_num;
    }
}
