using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    int i;
    Timer time;
    public GameObject battery;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        time = new Timer(10.0f);//배터리 지속 시간
    }

    // Update is called once per frame
    void Update()
    {
        if (time.IsDone)//시간이 지남에 따라
        {//배터리 잔량 감소
            battery.transform.GetChild(0).transform.GetChild((i++) % 4).gameObject.SetActive(false);
        }
    }

    //배터리 사용 시 time.TimerInit, 꺼져있던 배터리 잔량 true, i 초기화.
}
