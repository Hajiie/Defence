using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    public Sprite img;
    GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GameObject.Find("LockOpen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        btn.GetComponent<Image>().sprite = img;
    }
}
