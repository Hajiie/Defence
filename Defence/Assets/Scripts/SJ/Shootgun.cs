using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shootgun : MonoBehaviour
{
    private Vector3 CrossHairpos;

    static public int miss;

    private int hitCnt = 0;
    private int bulletCnt = 2; // initial bulletNum

    bool gameOver = false;

    public Text ScriptTxt;

    RaycastHit2D hit;

    Vector3 Start_Pos;
    Vector3 originPos;

    private float retroActionForce = 3.0f;
    public GameObject CrossHair;
    public GameObject Buggeyman;
    GameObject shootButton;
    


    // Start is called before the first frame update
    void Start()
    {    
        CrossHairpos = new Vector3(CrossHair.transform.position.x, CrossHair.transform.position.y);
        Start_Pos = CrossHair.transform.localPosition;
        originPos = CrossHair.transform.localPosition;
        ScriptTxt.text ="x" + bulletCnt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Start_Pos = CrossHair.transform.localPosition;
        CrossHairpos = new Vector3(CrossHair.transform.position.x, CrossHair.transform.position.y);

        Ray ray = new Ray(CrossHairpos, transform.forward);

        

        if (bulletCnt == 0 && hitCnt == 2) { } // hit all bullets then to next stage

        if (miss > 0)
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
        hit = Physics2D.Raycast(CrossHairpos, transform.forward, 15f); // cross-hair is Screencenter
        StartCoroutine(Shake());
        CheckTarget(hit);
        bulletCnt--;
        ShowbulletCnt();
        
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
    IEnumerator Shake()
    {
        Vector3 recoilBack = new Vector3(Start_Pos.x, retroActionForce, Start_Pos.z);

        while (CrossHair.transform.localPosition.y <= retroActionForce - 0.02f)
        {
            CrossHair.transform.localPosition = Vector3.Lerp(CrossHair.transform.localPosition, recoilBack, 1.0f);
            yield return null;
        }   

    }
}
