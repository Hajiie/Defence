using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    int battery_num;
    Timer time;
    Inventory Inven;
    public GameObject battery;

    bool IsLightOn = false;
    // Start is called before the first frame update
    void Start()
    {
        // Mng = GameObject.Find("ScriptMNG");
        Inven = this.GetComponent<Inventory>();//인벤토리 설정
        battery_num = Inven.BatteryNum;//인벤토리에서 가지고 있는 배터리 갯수 Get
        for (int i = Inven.BatteryNum; i < 4; i++)//현재 사용 할 수 있는 배터리만큼 표시
        {
            battery.transform.GetChild(i).gameObject.SetActive(false);
        }
        time = new Timer(5.0f);//배터리 지속 시간
        time.IsEnable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLightOn)
        {
            if (time.IsDone)//시간이 지남에 따라
            {//배터리 잔량 감소
                if (battery_num > 0)//OutofBound
                {
                    Inven.BatteryNum = -1;//배터리 사용 감소 초기화
                    battery_num = Inven.BatteryNum;
                    battery.transform.GetChild(battery_num).gameObject.SetActive(false);

                }
            }
        }
        IsBatteryGet();//배터리 얻었는지 체크
    }

    void IsBatteryGet()
    {
        if (battery_num < Inven.BatteryNum)//현재 사용하고 있는 배터리와 비교 시 인벤토리의 배터리가 늘었을 시 
        {
            battery_num = Inven.BatteryNum;//새롭게 초기화
            battery.transform.GetChild(battery_num - 1).gameObject.SetActive(true);//배터리양 만큼 배터리 표시
            //time.TimerInit();
        }
    }

    public void LightON()
    {
        if (IsLightOn)
        {
            IsLightOn = false;
            time.IsEnable = false;
        }
        else
        {
            IsLightOn = true;
            time.IsEnable = true;
        }
    }

}
