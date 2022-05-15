using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    void start()
    {

    }
    private void Update()
    {

    }
    public void Drag_object(string a)
    {
        StartCoroutine(MouseDrag());

    }

    IEnumerator MouseDrag()
    {
        while (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldObjectPositon = Camera.main.ScreenToWorldPoint(mouseDragPosition);
            this.transform.position = worldObjectPositon;
            yield return null;
        }
    }

}
