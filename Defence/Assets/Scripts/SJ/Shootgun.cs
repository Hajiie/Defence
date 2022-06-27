using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shootgun : MonoBehaviour
{
    private Vector3 ScreenCenter;

    static public int miss;

    private int hitCnt = 0;
    private int bulletCnt = 2; // initial bulletNum

    bool gameOver = false;

    public Text ScriptTxt;

    RaycastHit2D hit;

    GameObject Buggeyman;
    GameObject shootButton;
    // Start is called before the first frame update
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        ScriptTxt.text ="x" + bulletCnt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(ScreenCenter, transform.forward);

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
    public void OnclickFireGun()
    {
        ScreenCenter = Camera.main.ScreenToWorldPoint(ScreenCenter);
        
        hit = Physics2D.Raycast(ScreenCenter, transform.forward, 15f); // cross-hair is Screencenter

        CheckTarget(hit);
        bulletCnt--;
        ShowbulletCnt();
        transform.rotation = Quaternion.Euler(30, 0, 0);
    }
    void ShowbulletCnt()
    {
        
        ScriptTxt.text = "x" + bulletCnt.ToString(); // show the num of bullets
    }
    void CheckTarget(RaycastHit2D hit)
    {
        if (hit == Buggeyman) // if hits buggey
        {
            this.hitCnt++;
        }
        else miss++;
    }
}
