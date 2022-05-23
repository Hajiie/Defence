using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    CameraLocation currentLocation;
    List<CameraLocation> Cameralocations = new List<CameraLocation>(); 
    [SerializeField] List<Camera> Cameras = new List<Camera>();
    [SerializeField] List<GameObject> Backgrounds = new List<GameObject>();

    public GameObject isoffCamera;

    //public Vector3 ImageLocation;

    // 카메라 위치값 변수
    // 해당 위치 변수 + 제트값 같으면
    // 켜줘

    public enum CameraLocation // 메인 카메라 위치
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
        currentLocation = CameraLocation.BG_Lock; // 위치 정해주는 변수 위치 초기화보다 그냥 얘만 켜주면..
        for (int i = 0; i < Cameras.Count; i++)
        {
            if(i!= (int)currentLocation) // 얘 아니면 다 끄라고
            {
                Cameras[i].gameObject.SetActive(false);
                //Debug.Log(i);
            }
            // 나머지 카메라 다 꺼놓기
            // Debug.Log(i);
            Vector3 ImageLocation = new Vector3(Backgrounds[i].transform.position.x, Backgrounds[i].transform.position.y, Backgrounds[i].transform.position.z - 10);
            // 이미지 위치 받아주고
            Cameras[i].transform.position = ImageLocation;
            // 카메라 위치 옮겨주기 - 번호에 해당하는 이미지들의 위치 + z -10

        }
        // 현재 카메라 위치가 아니면 카메라[번호]를 꺼라
        // static?
        // 스타트문에서 카메라 위치는 다 옮겨져야함
    }

    void Update()
    {
        // 
        // 옮길 때마다 어느 화면인지 그 화면 위치로 확인 
        // 이미지 위치를 업데이트로 받고
        // 버튼 눌렀을 때 이미지의 카메라 "켜지게"
    }


    public void LeftArrow()
    {
        if (Cameras[(int)CameraLocation.BG_Lock]) // BG_Lock 화면이면
        {
            CameraOff(); // 해당 것만 켜고 나머지는 꺼야지
            Cameras[3].gameObject.SetActive(true);
        }
        else if (Cameras[(int)CameraLocation.BG_Bed])
        {
            CameraOff();
            Cameras[3].gameObject.SetActive(true);
        }
        else if (Cameras[(int)CameraLocation.BG_Lamp])
        {
            CameraOff();
            Cameras[3].gameObject.SetActive(true);
        }
        else if (Cameras[(int)CameraLocation.BG_Door])
        {
            CameraOff(); ;
            Cameras[3].gameObject.SetActive(true);
        }
    }

      public void CameraOff()
        {
        isoffCamera.gameObject.SetActive(false);
        }


        // 1이면 왼쪽은 몇번, 오른쪽은 몇번
        // 
        //Cameras[(int)currentLocation].gameObject.SetActive(true);
        // 해당 번호의 카메라를 켜주기
        // 지금 쓴 거는 마이너스 해서 이전 버튼 켜주기임
        // 이거 포문 쓰면 될 것 같은디 - 반복문 쓰면서
        // 옆버튼 누르면 ~로 이동
    
    
    public void RightArrow()
    {

    }
}
