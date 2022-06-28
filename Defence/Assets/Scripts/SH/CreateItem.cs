using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateItem : MonoBehaviour
{
    private bool IsFirstSearch;
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
        if (IsFirstSearch)
        {
            if (this.GetComponent<CameraView>().getCamera.name == "BG_Lock_OntheTable")
            {
                Instantiate(batteryOBJ).transform.position = new Vector3(10,20, 0);
            }
            else if (this.GetComponent<CameraView>().getCamera.name == "BG_Lock_OntheTable")
            {
                
            }
            IsFirstSearch = false;
        }
    }
}
