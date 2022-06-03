using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_CameraView : MonoBehaviour
{
    CameraLocation currentLocation;
    [SerializeField] List<Camera> Cameras = new List<Camera>();
    [SerializeField] List<GameObject> Backgrounds = new List<GameObject>();

    Camera NowCamera; // 다른 스트립트는 안갖고옴
    //CameraView cameraview; // Stage1 스크립트 갖고옴
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

        //BuggeyOnOff(nextcamera); // 부기 등장 확률 함수 / 카메라 이동할 때마다 실행
    }

    public void DownArrow() // 아래 이동 버튼 눌렀을 때
    {
        NextCameraOn((int)CameraLocation.BG_Start); // 카메라 함수 들고와서?! 그런가.. 아ㅏㅏ 함수 걍 
    }
}
