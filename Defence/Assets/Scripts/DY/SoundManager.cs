using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;

    //AudioSources List
    public AudioSource bgmSource; // basic main bgm
    public AudioSource effectSource; // commoon sfx
    public AudioSource buttonSource; // UI button sfx
    public AudioSource playerAudioSource; // sfx for player(main character)

    //BGM AudioClip
    public AudioClip startBGM;
    public AudioClip stage1BGM;
    public AudioClip stage3BGM;
    public AudioClip endingBGM;

    //Common Effect
    public AudioClip appearBuggymanEffect; // 부기맨 등장
    public AudioClip breakWindowEffect; // 창문/총진열장 깨짐
    public AudioClip stepOnFragmentEffect; // 유리파편 밟음
    public AudioClip openClosetEffect; // 서랍/옷장 열기

    //Stage1 Effect
    public AudioClip pickALockEffect; // 문 따기
    public AudioClip openDoorEffect; // 문 열리는 소리
    public AudioClip hideInBedEffect; // 침대에 숨기

    //stage3 Effect
    public AudioClip loadGunEffect; // 총 장전
    public AudioClip shootGunEffect; // 총 쏘기
    public AudioClip breakBoardEffect; // 판자 부서짐 1
    public AudioClip breakAllEffect; // 모든 판자 부서짐
    public AudioClip hearSthEffect; // 발포 후 이명 소리
    void Start()
    {
        if(inst == null)
        {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        bgmSource.clip = startBGM;
        bgmSource.Play();
    }

    //BGM
    public void BGMStop()
    {
        bgmSource.Stop();
    }

    public void BGMPlay()
    {
        bgmSource.Play();
    }
    public void StartBGMPlay()
    {
        if(bgmSource.clip == startBGM)
        {
            return;
        }
        bgmSource.clip = startBGM;
        bgmSource.Play();
    }
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip)
        {
            return;
        }
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    // Effect
    public void EffectPlay(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }
    public void ButtonEffectPlay(AudioClip clip)
    {
        buttonSource.clip = clip;
        buttonSource.Play();
    }
}