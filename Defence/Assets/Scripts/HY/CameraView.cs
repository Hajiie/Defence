using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    CameraLocation currentLocation;
    [SerializeField] List<Camera> Cameras = new List<Camera>();
    [SerializeField] List<GameObject> Backgrounds = new List<GameObject>();

    public int currentImgLocation;
    public GameObject downArrow;
    public GameObject upArrow;
    public GameObject updownArrow;
    public GameObject leftrightArrow;

    public enum CameraLocation // 옮겨진 카메라 위치
    {
        BG_Lock = 0, // 처음 화면
        BG_Lock_Drawer = 1, // 처음 화면 - 서랍
        BG_Lock_Closet = 2, // 처음 화면 - 옷장
        BG_Bed = 3, // 침실   
        BG_UndertheBed = 4, // 침대 아래
        BG_Lamp = 5, // 램프 있는 방
        BG_Lamp_ToyBox = 6, // 장난감 상자
        BG_Lamp_Lamp = 7, // 램프
        BG_Lamp_Drawer = 8, // 서랍
        BG_Lamp_Window = 9, // 창문
        BG_Door = 10, // 문 있는 방
        BG_Door_Door = 11, // 문 있는 방
    }

    void Start()
    {
        currentLocation = CameraLocation.BG_Lock;
        for (int i = 0; i < Cameras.Count; i++)
        {
            if (i != (int)currentLocation) // 처음화면 제외하고 off
            {
                Cameras[i].gameObject.SetActive(false);
            }
            Vector3 ImageLocation = new Vector3(Backgrounds[i].transform.position.x, Backgrounds[i].transform.position.y, Backgrounds[i].transform.position.z - 10);
            // 이미지 위치 받아주고
            Cameras[i].transform.position = ImageLocation;
            // 카메라 위치 옮겨주기 - 번호에 해당하는 이미지들의 위치 + z -10
        }
    }

    void Update()
    {
        for (int i = 0; i < Cameras.Count; i++)
        {
            if (Cameras[i].gameObject.activeSelf == true) // 해당 카메라가 켜져있으면
            {
                currentImgLocation = i; // 해당 카메라 위치 = 현재 위치
                //UpDdownArrowOn();
            }
        }
    }


    public void LeftArrow() // 왼쪽 이동버튼 눌렀을 때
    {
        if (currentImgLocation == ((int)CameraLocation.BG_Lock))
        {
            NextCameraOn((int)CameraLocation.BG_Bed);
        }
        else if (currentImgLocation == ((int)CameraLocation.BG_Bed))
        {
            NextCameraOn((int)CameraLocation.BG_Lamp); 
        }
        else if (currentImgLocation == ((int)CameraLocation.BG_Lamp))  
        {
            NextCameraOn((int)CameraLocation.BG_Door); 
        }  
        else if (currentImgLocation == ((int)CameraLocation.BG_Door))  
        {
            NextCameraOn((int)CameraLocation.BG_Lock); 
        }
        else
        {
            downArrow.SetActive(false);
        }

        // 나머지 화면인 경우 Setactive(false)
    }

    public void RightArrow() // 오른쪽 이동 버튼 눌렀을 때
    {
        if (currentImgLocation == ((int)CameraLocation.BG_Lock))
        {
            NextCameraOn((int)CameraLocation.BG_Door);
        }
        else if (currentImgLocation == ((int)CameraLocation.BG_Door))
        {
            NextCameraOn((int)CameraLocation.BG_Lamp);
        }
        else if (currentImgLocation == ((int)CameraLocation.BG_Lamp))
        {
            NextCameraOn((int)CameraLocation.BG_Bed);
        }
        else if (currentImgLocation == ((int)CameraLocation.BG_Bed))
        {
            NextCameraOn((int)CameraLocation.BG_Lock);
        }
       
        // 나머지 화면인 경우 Setactive(false)
    }

    public void UpArrow() // 위 버튼을 눌렀을 때
    {
        if (currentImgLocation == ((int)CameraLocation.BG_UndertheBed)) // 현재 위치가 침대아래일 때
        {
            NextCameraOn((int)CameraLocation.BG_Bed); // 침대 이동하고;
        }
    }

    public void DownArrow()
    {
        if (currentImgLocation == ((int)CameraLocation.BG_Bed)) // 현재 위치가 침대일 때
        {
            NextCameraOn((int)CameraLocation.BG_UndertheBed);
        }
    }

    /*public void UpDdownArrowOn() // 위아래 화살표 켜고 꺼주기
    {
        if (currentImgLocation == ((int)CameraLocation.BG_Bed))
        {
            downArrow.SetActive(true); // BG_Bed일 때 켜기
        }
        else if (currentImgLocation == ((int)CameraLocation.BG_UndertheBed))
        {
            upArrow.SetActive(true); // BG_Bed일 때 켜기 // 아 안꺼주는 구나.. // if문 어따 붙여야 되지
        }
        else
        {
            updownArrow.SetActive(false);
        }
    }
    */

    public void NextCameraOn(int nextcamera) // 입력받은 번호의 카메라 켜주기
    {
        for (int i = 0; i < Cameras.Count; i++) // 받아서 돌리는데, 받은 번호가 나오면 그 번호 화면만 카메라 켜기
        {
            Cameras[nextcamera].gameObject.SetActive(true);

            if (i != nextcamera)
            {
                Cameras[i].gameObject.SetActive(false);
            }
        }
    }
}

