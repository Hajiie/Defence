using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    Vector3 Start_Pos;
    public GameObject CrossHair;
    void Start()
    {
        Start_Pos = transform.localPosition;
    }
    void Update()
    {
        
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        float timer = 0;
        duration = 2.0f;
        magnitude = 3.0f;
        while (timer <= duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitSphere * magnitude + Start_Pos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = Start_Pos;
    }
}
