using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateItem : MonoBehaviour
{
    private bool IsFirstSearch;
    public GameObject itemOBJ;
    public GameObject batteryOBJ;

    public GameObject clipOBJ;

    public GameObject bulletOBJ;
    // Start is called before the first frame update
    void Start()
    {
        IsFirstSearch = true;
    }

    // Update is called once per frame
    void Update()
    {
        Search();
    }

    void Search()
    {
        if (this.GetComponent<CameraView>().getCamera.name == "BG_Lock_OntheTable"||this.GetComponent<CameraView>().getCamera.name == "BG_UndertheBed")
        {
            print("1 IF문 성공");
            if (IsFirstSearch)
            {
                print("2 IF문 성공");
                Instantiate(batteryOBJ, itemOBJ.transform).transform.position =
                    new Vector3(0,this.GetComponent<CameraView>().getCamera.transform.position.y,0);
                IsFirstSearch = false;
                //Instantiate(batteryOBJ).transform.parent=itemOBJ.transform; //.transform.position = new Vector3(10,20, 0);
            }
            
            
        }
    }
}
