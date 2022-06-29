using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionBtn : MonoBehaviour
{
    private bool isOn;
    public float ScreenSpeed=0.5f;
    public GameObject CreditBG;
    // Start is called before the first frame update
    public Button CreditBtn;
    public Button BackBtn;
    public AudioMixer audioMixer;

    public Slider audioSlider;
    void Start()
    {
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CreditBG.transform.GetChild(0).gameObject.activeSelf)
        {
            CreditBG.transform.GetChild(0).localPosition =
                Vector3.MoveTowards(CreditBG.transform.GetChild(0).localPosition, new Vector3(0f, 1300f, 0f), ScreenSpeed);
            
            if (CreditBG.transform.GetChild(0).localPosition.y == 1300f)
            {
                CreditBG.transform.GetChild(0).localPosition = new Vector3(0f, -1300f, 0f);
                CreditBG.transform.GetChild(0).gameObject.SetActive(false);
                BackBtn.gameObject.SetActive(true);
            }
        }
    }

    public void Option()
    {
        if (!isOn)
        {
            CreditBtn.gameObject.SetActive(true);
            audioSlider.gameObject.SetActive(true);
            isOn = true;
        }
        else
        {
            CreditBtn.gameObject.SetActive(false);
            audioSlider.gameObject.SetActive(false);
            isOn = false;
        }
    }

    public void Credit()
    {
        CreditBG.SetActive(true);
        CreditBG.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Back()
    {
        CreditBG.SetActive(false);
        BackBtn.gameObject.SetActive(false);
    }
}
