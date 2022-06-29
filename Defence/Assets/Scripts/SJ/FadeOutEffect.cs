using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutEffect : MonoBehaviour
{
    float time;
    public float fadeTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (time < fadeTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 5f - time / fadeTime);
        }
        else
        {
            time = 0;
            this.gameObject.SetActive(false);
        }
        time += Time.deltaTime;
    }
    public void resetEffect()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        this.gameObject.SetActive(true);
    }
}
