using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    RaycastHit2D hit;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        //mainCamera.orthographicSize = (Screen.height / (Screen.width / 16f)) / 9f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
        }
    }

    public RaycastHit2D getHit
    {
        get { return hit; }//맞은 물체 반환.
    }

    public void test()
    {
        print("dd");
    }
}
