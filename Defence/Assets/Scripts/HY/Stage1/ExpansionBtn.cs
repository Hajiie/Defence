using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExpansionBtn: MonoBehaviour
{
    [SerializeField] List<GameObject> btns = new List<GameObject>(); // 확대 버튼들
    [SerializeField] List<int> hp = new List<int>();
    [SerializeField] List<Image> bars = new List<Image>();

    public CameraView cameraview;
    public Inventory inven;
    public Open open;
    //public Clip clip;
    public GameObject OpenGauge;
    public string sceneName;



    private void Start()
    {
        //clip = GetComponent<Clip>();
    }
    public void Expand() // 가구 버튼 누르면 클로징 씬으로 이동 - 해당 버튼이 SetActive(true)인가?

    {
        for (int i = 0; i < btns.Count; i++) // 버튼 중에서 돌리고
        {
            if (btns[i].activeSelf) // 해당 확대 버튼이 active면
            {
                //Debug.Log(i);
                switch (i) // 버튼 번호에 따라
                {
                    case 0: // 옷장
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lock_Closet);
                        break;
                    case 1: // 책상 위
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lock_OntheTable);
                        break;
                    case 2: // 책상 서랍
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lock_IntheTable);
                        break;
                    case 3: // 침대
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Bed_Bed);
                        break;
                    case 4: // 장난감 박스
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lamp_ToyBox);
                        break;
                    case 5: // 램프
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lamp_Lamp);
                        break;
                    case 6: // 서랍
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lamp_Drawer);
                        break;
                    case 7: // 창문
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lamp_Window);
                        break;
                    case 8: // 문
                        //open.OpenDoor();
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Door_Door);
                        break;
                    default:
                        break;
                        //침대 클로징 추가
                }

                btns[i].SetActive(false);
                this.GetComponent<RayCast>().getHit = new RaycastHit2D();
                break;
            }
        }
    }

    public void KeyOnclick() // Door_Door에서 나오는 KeyBtn
    {
        cameraview.KeyBtn.SetActive(false); // Key버튼 끄기
        OpenGauge.SetActive(true); // 게이지 이미지 켜주기
        this.GetComponent<Inventory>().ClipNum = -1;
        // inven의 clip 값을 바꿔줘야함
        // clip에서 업뎃됨
    }

    public void KeyIconOnClick() // KeyBtn 누르면 나오는 KeyIconBtn
    {


        if (hp[0] == 0 && !(hp[1] == 0))
            GaugebarDown(1); // 두번째 바

        else if(hp[0] == 0 && hp[1] == 0)
        {
            GaugebarDown(2); // 세번째 바
            //SceneManager.LoadScene(sceneName);
            // Stage 3으로 넘어가기 
        }

        else
            GaugebarDown(0);

        // 열쇠 아이콘 50번 터치해야 게이지 하나 채움
        // 3줄의 게이지는 자동적으로 다음 줄로 넘어감
    }

    public void HideOnClick()
    {
        // 부기맨 등장 효과음 줄어들게
    }

    void GaugebarDown(int i) // bar[i]의 fillAmount 감소
    {
        hp[i] -= 1;
        bars[i].fillAmount = hp[i] * 0.02f;
    }
}
