using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float prvTime;
    private float nowTime;
    private float targetTime;

    private bool isRepeat = true;
    private bool reverse = false;
    private bool enable = true;

    public float TargetTime
    {
        get { return targetTime; }
        set { targetTime = value; }
    }

    public bool IsEnable
    {
        get { return enable; }
        set
        {
            enable = value;
            TimerInit();
        }
    }

    public bool IsDone
    {
        get
        {
            if (IsEnable)
            { nowTime = Time.time; }

            if (nowTime - prvTime >= targetTime && enable)
            {
                prvTime = Time.time;
                return true && !reverse;
            }

            return false || (reverse && IsEnable);
        }
    }

    public bool Reverse
    {
        get
        {
            return reverse;
        }
        set
        {
            reverse = value;
        }
    }

    public float RemainTime
    {
        get
        {
            return targetTime - (nowTime - prvTime);
        }
    }

    /// <summary>
    /// Timer Ctor. this class is can use like Timer.
    /// </summary>
    /// <param name="targetTime">알람이 울릴 주기.</param>
    public Timer(float targetTime)
    {
        this.targetTime = targetTime;
        prvTime = Time.time;
        nowTime = Time.time;
    }

    public void TimerInit()
    {
        nowTime = Time.time;
        prvTime = Time.time;
    }
}

