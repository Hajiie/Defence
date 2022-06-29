using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateItem : MonoBehaviour
{
    private bool IsFirstSearch;
    private bool IsInRoom;
    public GameObject itemOBJ;
    public GameObject batteryOBJ;

    private GameObject createBattery;

    public GameObject clipOBJ;

    public GameObject bulletOBJ;
    // Start is called before the first frame update
    void Start()
    {
        IsFirstSearch = true;
        IsInRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        Search();
    }



    void Search()
    {
        if (IsFirstSearch)
        {
            if (this.GetComponent<CameraView>().getCamera.name == "BG_Lock_OntheTable")
            {
                createBattery=Instantiate(batteryOBJ, itemOBJ.transform);
                createBattery.transform.position = new Vector3(0,20,-1);
                IsFirstSearch = false;
                IsInRoom = false;
                return;
                //Instantiate(batteryOBJ).transform.parent=itemOBJ.transform; //.transform.position = new Vector3(10,20, 0);
            }
            else if (this.GetComponent<CameraView>().getCamera.name == "BG_UndertheBed")
            {
                createBattery=Instantiate(batteryOBJ, itemOBJ.transform);
                createBattery.transform.position = new Vector3(-40,20,-1);
                    
                IsFirstSearch = false;
                IsInRoom = false;
                return;
            }
        }

        if (!this.GetComponent<BuggeymanBtn>().IsBuggey && IsInRoom&&!IsFirstSearch)
        {
            int rand = Random.Range(0, 2);//부기맨이 안 떴으므로 반응 없음과 배터리는 50% 확률을 가짐.
            if (this.GetComponent<CameraView>().getCamera.name == "BG_Lock_OntheTable")
            {
                if (rand==0)
                {
                    createBattery=Instantiate(batteryOBJ, itemOBJ.transform);
                    createBattery.transform.position = new Vector3(0,20,-1);
                }
                IsInRoom = false;
            }
            else if (this.GetComponent<CameraView>().getCamera.name == "BG_UndertheBed")
            {
                if (rand==0)
                {
                    createBattery=Instantiate(batteryOBJ, itemOBJ.transform);
                    createBattery.transform.position = new Vector3(-40,20,-1);
                }
                IsInRoom = false;
            }
        }
        


        if (this.GetComponent<CameraView>().getCamera.name != "BG_Lock_OntheTable" &&
            this.GetComponent<CameraView>().getCamera.name != "BG_UndertheBed")
        {
            IsInRoom = true;
            Destroy(createBattery);
        }
    }
}
