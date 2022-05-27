using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionBtn: MonoBehaviour
{
    [SerializeField] List<GameObject> btns = new List<GameObject>(); // 확대 버튼들

    public CameraView cameraview;

    public void Expand() // 버튼이 켜져있는데 눌렀을 경우 이동 시키기 : 무슨 버튼일 경우? 
    {

        for (int i = 0; i < btns.Count; i++) // 버튼 중에서 돌리고
        {
            if (btns[i].activeSelf) // 해당 확대 버튼이 active면
            {
                //Debug.Log(i);
                switch (i) // 버튼 번호에 따라
                {
                    case 0:
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lock_Closet);
                        break;
                    case 1:
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lock_Drawer);
                        break;
                    case 2:
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lamp_ToyBox);
                        break;
                    case 3:
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lamp_Lamp);
                        break;
                    case 4:
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lamp_Drawer);
                        break;
                    case 5:
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Lamp_Window);
                        break;
                    case 6:
                        cameraview.NextCameraOn((int)CameraView.CameraLocation.BG_Door_Door);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    
}
