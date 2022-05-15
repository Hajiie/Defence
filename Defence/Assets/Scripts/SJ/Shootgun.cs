using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootgun : MonoBehaviour
{
    private Vector3 ScreenCenter;

    static public int miss;

    private int hitCnt = 0;
    private int bulletCnt = 2; // initial bulletNum

    bool gameOver = false;

    GameObject shootButton;
    // Start is called before the first frame update
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelHeight / 2, Camera.main.pixelWidth / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);

        if (bulletCnt == 0 && hitCnt == 2) { } // hit all bullets then to next stage

        if (miss >= 2)
        {
            gameOver = true;
        }
        if (gameOver)
        {
            return; // back to prev stage
        }
    }
    void FireGun()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter); // cross-hair is Screencenter
        Physics.Raycast(ray, out hit, Mathf.Infinity);

        CheckTarget(hit); 

        bulletCnt--;

    }
    void CheckTarget(RaycastHit hit)
    {
        if (hit.transform.tag == "Monster") // need to fix tag of monster
        {
            this.hitCnt++;
        }
        else miss++;
    }
}
