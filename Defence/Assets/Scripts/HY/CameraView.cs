using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    CameraLocation currentLocation;
    [SerializeField] List<Camera> Cameras = new List<Camera>();
    [SerializeField] List<GameObject> Backgrounds = new List<GameObject>();

    Camera NowCamera;
    public Camera getCamera
    {
        get { return NowCamera; }
    }

    public int currentImgLocation;
    public GameObject updownArrow;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftrightArrow;

    //int [] YesLeftRight = {(int)CameraLocation.BG_Lock, (int)CameraLocation.BG_Bed,(int)CameraLocation.BG_Lamp,(int)CameraLocation.BG_Door};
    //int[] noDown = { 4, 7, 10 };

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
        NowCamera = Cameras[(int)CameraLocation.BG_Lock];
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
        // start문에서 다 꺼주고 시작해야되나?
    }

    void Update()
    {
        for (int i = 0; i < Cameras.Count; i++)
        {
            if (Cameras[i].gameObject.activeSelf == true) // 해당 카메라가 켜져있으면
            {
                currentImgLocation = i; // 해당 카메라 위치 = 현재 위치  
                //ArrowOnOff();
            }

            // 현재 카메라 위치(i)가 배열에 포함되어 있으면(조건 보고)
        }
        // 왼쪽 오른쪽은 0,3,7,10 일 때만 켜주기
        // 위쪽은 4일 때만
        // 아래쪽은 1,2,3,5,6,8,9,11일 때만 켜주기
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

    public void UpArrow() // 위 이동 버튼 눌렀을 때
    {
        if (currentImgLocation == ((int)CameraLocation.BG_UndertheBed))
        // BG_Bed로 되돌아가기
        {
            NextCameraOn((int)CameraLocation.BG_Bed);
        }
    }

    public void DownArrow() // 아래 이동 버튼 눌렀을 때
    {
        if (currentImgLocation == ((int)CameraLocation.BG_Bed)) // 현재 위치가 침대일 때
        {
            NextCameraOn((int)CameraLocation.BG_UndertheBed);
        }
        else if(currentImgLocation == ((int)CameraLocation.BG_Lock_Drawer)|| currentImgLocation == ((int)CameraLocation.BG_Lock_Closet))
        // BG_Lock으로 되돌아가기
        {
            NextCameraOn((int)CameraLocation.BG_Lock);
        }
        else if (currentImgLocation == ((int)CameraLocation.BG_Lamp_ToyBox) || currentImgLocation == ((int)CameraLocation.BG_Lamp_Lamp) || currentImgLocation == ((int)CameraLocation.BG_Lamp_Drawer) || currentImgLocation == ((int)CameraLocation.BG_Lamp_Window))
        // BG_Lamp으로 되돌아가기
        {
            NextCameraOn((int)CameraLocation.BG_Lamp);
        }
        else if (currentImgLocation == ((int)CameraLocation.BG_Door_Door))
        // BG_Door로 되돌아가기
        {
            NextCameraOn((int)CameraLocation.BG_Door);
        }

    }

    public void NextCameraOn(int nextcamera) // 입력받은 번호의 카메라 켜주기
    {
        for (int i = 0; i < Cameras.Count; i++) // 받아서 돌리는데, 받은 번호가 나오면 그 번호 화면만 카메라 켜기
        {
            Cameras[nextcamera].gameObject.SetActive(true);
            NowCamera = Cameras[nextcamera];
            if (i != nextcamera)
            {
                Cameras[i].gameObject.SetActive(false);
            }
        }
    }  

    public void ArrowOnOff()
    {
        if (!(currentImgLocation == (int)CameraLocation.BG_Lock|| currentImgLocation == (int)CameraLocation.BG_Bed || currentImgLocation == (int)CameraLocation.BG_Lamp || currentImgLocation == (int)CameraLocation.BG_Door))
        // 원래 켜져 있는데, 메인 4개 + 침대 밑 아니면 다 꺼줘
        // 메인 4개가 아니면?
        {
            leftrightArrow.SetActive(false);// 왼쪽 오른쪽 이동 꺼주기
            downArrow.SetActive(true); // 이렇게 하면 침대 밑도 켜지겠지
        }
        else if (!(currentImgLocation == (int)CameraLocation.BG_UndertheBed))
            // 원래 켜져있는데, 침대 밑 제외하고 다 꺼주기
            // 침대 밑이 아니면?
            // 껐으면 다시 켜야되는데,, 
        {
            upArrow.SetActive(false); // 위에 버튼 켜주기
        }
 

        //else if()
        // 현재 위치가 침대 아래가 아니면 꺼주기
                
               
            // i가 배열에 들어있으면
       
    }
}

