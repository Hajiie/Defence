using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int battery_num = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetBatteryNum()//배터리 갯수 Get
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
}
