using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    CameraLocation currentLocation;
    [SerializeField] List<Camera> Cameras = new List<Camera>();
    [SerializeField] List<GameObject> Backgrounds = new List<GameObject>();

    Camera NowCamera;
    public BuggeymanBtn buggeymanbtn;
    public ExpansionBtn expansionbtn;

    public Camera getCamera
    {
        get { return NowCamera; }
    }

    int currentImgLocation;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftrightArrow;
    public GameObject HideBtn;
    public GameObject KeyBtn;

    public enum CameraLocation // 옮겨진 카메라 위치
    {
        BG_Lock = 0, // 처음 화면
        BG_Lock_OntheTable = 1, // 처음 화면 - 서랍
        BG_Lock_IntheTable = 13,
        BG_Lock_Closet = 2, // 처음 화면 - 옷장
        
        BG_Bed = 3, // 침실   
        BG_Bed_Bed = 12, // 침대
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
    }

    void Update()
    {
        for (int i = 0; i < Cameras.Count; i++)
        {
            if (Cameras[i].gameObject.activeSelf == true) // 해당 카메라가 켜져있으면
            {
                currentImgLocation = i; // 해당 카메라 위치 = 현재 위치  
                ArrowOnOff(); // 이동 버튼
                //BuggeyOnOff(i); // 부기 등장 함수
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
        else if(currentImgLocation == (int)CameraLocation.BG_Bed_Bed)
        // BG_Bed로 되돌아가기
        {
            NextCameraOn((int)CameraLocation.BG_Bed);
        }
        else if(currentImgLocation == ((int)CameraLocation.BG_Lock_IntheTable)|| currentImgLocation == ((int)CameraLocation.BG_Lock_OntheTable)|| currentImgLocation == ((int)CameraLocation.BG_Lock_Closet))
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

    public void ArrowOnOff() // 화살표 버튼
    {
        if (currentImgLocation == (int)CameraLocation.BG_Lock || currentImgLocation == (int)CameraLocation.BG_Bed || currentImgLocation == (int)CameraLocation.BG_Lamp || currentImgLocation == (int)CameraLocation.BG_Door)
            // Lock,Lamp,Bed,Door에서 왼쪽오른쪽 버튼 켜주기
        {
            leftrightArrow.SetActive(true);
            upArrow.SetActive(false);
            KeyBtn.SetActive(false); 
            HideBtn.SetActive(false);

            if (!(currentImgLocation == (int)CameraLocation.BG_Bed))// Bed에서 아래 버튼 켜주기
            {
                downArrow.SetActive(false);
            }
            else
                downArrow.SetActive(true);
        }
        else // 클로징 화면 + UndertheBed
        {
            leftrightArrow.SetActive(false);
            downArrow.SetActive(true);
            if (currentImgLocation == (int)CameraLocation.BG_UndertheBed) //undertheBed에서만 위 버튼 켜주기   
            {
                upArrow.SetActive(true);
                downArrow.SetActive(false);
            }
            else
            {
                upArrow.SetActive(false);

                /*if (currentImgLocation == (int)CameraLocation.BG_Door_Door) // Door_Door이면
                { 
                    if (expansionbtn.OpenGauge.activeSelf) // 게이지 창이 뜬 상태일 경우
                        KeyBtn.SetActive(false);
                    else
                    {
                        KeyBtn.SetActive(true);
                    }
                    // 얘 밖으로 빼기 - 뒤로 가기 했을 때 안 사라짐
                }
                // 클립 한 개 이상 모았을 때 등장

                else if (currentImgLocation == (int)CameraLocation.BG_Bed_Bed) // Bed_Bed에서 Hide 버튼 켜주기
                    HideBtn.SetActive(true);*/
            }

        }
    }

    public void BuggeyOnOff(int x) // x = 현재 위치 / 부기맨 + 버튼 등장
    {
        // 위치만 그때그때 받고,
        // 이동할 때만 함수 실행 시켜야함

        switch(x)
        {
            case (int)CameraLocation.BG_Lock_Closet: // 옷장
                buggeymanbtn.BuggeyAppearCloset();
                break;            

            case (int)CameraLocation.BG_UndertheBed: // 침대 밑
                buggeymanbtn.BuggeyAppearUndertheBed();
                break;
            
            case (int)CameraLocation.BG_Bed_Bed: // 침대 클로징
                HideBtn.SetActive(true); // Hide 버튼
                break;            

            case (int)CameraLocation.BG_Lamp_Drawer: //  서랍
                buggeymanbtn.BuggeyAppearDrawer();
                Debug.Log("운이 좋았다");

                break;            

            case (int)CameraLocation.BG_Door_Door:
                buggeymanbtn.BuggeyAppearDoor_Door();// 문 클로징
                KeyBtn.SetActive(true); // Key 버튼
                // 근데 이게 업데이트로 들어가서 계속 켜지는 거 아닝가?
                //ㅋ맞음 if문 해야되낭,,,,
                break;

            default:
                KeyBtn.SetActive(false);
                HideBtn.SetActive(false);
                expansionbtn.OpenGauge.SetActive(false);
                break;
        }
        // 업데이트에 넣으니까 부기 등장할 때까지 찾는데
        // 어따 넣어야되지???

            
        // 아냐 걍 함수 자체로 갖고와
        // 스위치로 어디일 때 부기맨 함수 실행,
        // 초기화 필수
    }
}


