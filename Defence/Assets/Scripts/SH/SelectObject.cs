using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public GameObject ObjBtn;
    public Object obj;

    public GameObject scpMng;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (scpMng.GetComponent<RayCast>().getHit != this)
        {
            ObjBtn.SetActive(false);
        }
    }
}
