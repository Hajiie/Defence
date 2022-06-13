using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_CameraView : MonoBehaviour // Stage3 카메라 이동
{
    CameraLocation currentLocation;
    [SerializeField] List<Camera> Cameras = new List<Camera>();
    [SerializeField] List<GameObject> Backgrounds = new List<GameObject>();

    Camera NowCamera; // 다른 스트립트는 안갖고옴
    //CameraView cameraview; // Stage1 스크립트 갖고옴
    BuggeymanBtn buggeymanscript;
    public GameObject downArrow;

    int currentImgLocation;

    public enum CameraLocation
    {
        BG_Start = 0,
        BG_Door = 1,
        BG_Closet = 2,
        BG_Glass = 3,
        BG_Box = 4,
    }

    private void Start() // 카메라 이동
    {
        currentLocation = CameraLocation.BG_Start;
        NowCamera = Cameras[(int)CameraLocation.BG_Start];
        for (int i = 0; i < Cameras.Count; i++)
        {
            if (i != (int)currentLocation)
            {
                Cameras[i].gameObject.SetActive(false);
            }
            Vector3 ImageLocation = new Vector3(Backgrounds[i].transform.position.x, Backgrounds[i].transform.position.y, Backgrounds[i].transform.position.z - 10);
            Cameras[i].transform.position = ImageLocation;
        }
    }

    private void Update()
    {
        for (int i = 0; i < Cameras.Count; i++)
        {
            if (Cameras[i].gameObject.activeSelf == true) // 해당 카메라가 켜져있으면
                currentImgLocation = i;

            if (!(currentImgLocation == (int)CameraLocation.BG_Start)) // 전체화면 아니면
            {
                downArrow.SetActive(true);
            }
            else
                downArrow.SetActive(false);
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

        BuggeyOnOff(nextcamera); // 부기 등장 확률 함수 / 카메라 이동할 때마다 실행
    }

    public void DownArrow() // 아래 이동 버튼 눌렀을 때
    {
        NextCameraOn((int)CameraLocation.BG_Start); // 카메라 함수 들고와서?! 그런가.. 아ㅏㅏ 함수 걍 
    }

    // BG_Closet 에서 '스프라이트 바꿔지면 or 스프라이트 켜지면'이라는 조건 필요
    // 옷장 열리면 부기맨 등장
    // 10초 지나면 부기맨 등장

    public void BuggeyOnOff(int x) // x = 현재 위치 / 부기맨 + 버튼 등장
    {
        // 위치만 그때그때 받고,
        // 이동할 때만 함수 실행 시켜야함
        /*switch (x)
        {
            case (int)CameraLocation.BG_Lock_Closet: // 옷장
                buggeymanbtn.BuggeyAppearCloset();
                break;

            case (int)CameraLocation.BG_UndertheBed: // 침대 밑
                buggeymanbtn.BuggeyAppearUndertheBed();
                HideBtn.SetActive(true);
                break;

            case (int)CameraLocation.BG_Bed_Bed: // 침대 클로징
                HideBtn.SetActive(true); // Hide 버튼
                break;

            case (int)CameraLocation.BG_Lamp_Drawer: //  서랍
                buggeymanbtn.BuggeyAppearDrawer();
                break;

            case (int)CameraLocation.BG_Door_Door:
                buggeymanbtn.BuggeyAppearDoor_Door();// 문 클로징
                KeyBtn.SetActive(true); // Key 버튼 - 현재는 NextCamera() 실행 안돼서 시간도 안먹고 버튼 안 뜸
                break;

            default:
                KeyBtn.SetActive(false);
                HideBtn.SetActive(false);
                buggeymanbtn.buggey.SetActive(false); // 일단 부기 꺼질 수 있게
                expansionbtn.OpenGauge.SetActive(false);
                break;
        }
        */
    }

    // Stage3 부기맨 등장 확률 받으면 위치 지정해주고 함수 넣어주면 됨
}
