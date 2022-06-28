using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairCtrl : MonoBehaviour
{
    float speed = 2.0f;
    float xMin = -1870, xMax = 1870, yMin = -1030, yMax = 1030; // depend on CrossHair's size
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        Vector3 moveVelocity1 = Vector2.zero;
        Vector3 moveVelocity2 = Vector2.zero;
        var curPos = transform.position;

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse Y") > 0)
            {
                moveVelocity1 = Vector2.up;
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                moveVelocity1 = Vector2.down;
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                moveVelocity1 = Vector2.right;
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                moveVelocity1 = Vector2.left;
            }

            if (Input.GetAxis("Mouse X") < 0 && Input.GetAxis("Mouse Y") < 0)
            {
                moveVelocity1 = Vector2.left;
                moveVelocity2 = Vector2.down;
            }
            if (Input.GetAxis("Mouse X") < 0 && Input.GetAxis("Mouse Y") > 0)
            {
                moveVelocity1 = Vector2.left;
                moveVelocity2 = Vector2.up;
            }
            if (Input.GetAxis("Mouse X") > 0 && Input.GetAxis("Mouse Y") < 0)
            {
                moveVelocity1 = Vector2.right;
                moveVelocity2 = Vector2.down;
            }
            if (Input.GetAxis("Mouse X") > 0 && Input.GetAxis("Mouse Y") > 0)
            {
                moveVelocity1 = Vector2.right;
                moveVelocity2 = Vector2.up;
            }

            curPos += (moveVelocity1 + moveVelocity2) * speed;
            curPos.x = Mathf.Clamp(curPos.x, xMin, xMax);
            curPos.y = Mathf.Clamp(curPos.y, yMin, yMax);
            transform.position = curPos;
        }
    }
}
