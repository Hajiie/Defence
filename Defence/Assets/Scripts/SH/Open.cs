using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    public Sprite img;
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position == new Vector3(-60, 5, -10) && this.GetComponent<RayCast>().getHit && this.GetComponent<ControlLight>().HandLight.activeSelf)
        {
            btn.SetActive(true);
        }
        else
        {
            btn.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        if (this.GetComponent<Inventory>().ClipNum > 0)
        {
            btn.GetComponent<Image>().sprite = img;
            this.GetComponent<Inventory>().ClipNum = -1;
        }
    }
}
