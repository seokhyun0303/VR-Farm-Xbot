using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Meta.WitAi;

public class npctext : MonoBehaviour
{
    // Start is called before the first frame update
    public int step;
    public int checkstep;
    [SerializeField] private TextMeshProUGUI textTitle;
    AudioSource audio;
    AudioClip tts1, tts2, tts3, tts4;
    float curtime;
    void Start()
    {
        step = 0;
        checkstep = 1;
        curtime = 0;  
        audio = GetComponent<AudioSource>();    
        tts1 = Resources.Load("tts1") as AudioClip;
        tts2 = Resources.Load("tts2") as AudioClip;
        tts3 = Resources.Load("tts3") as AudioClip;
        tts4 = Resources.Load("tts4") as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        if (checkstep == 1 && step == 0)
        {
            textTitle.text = "VR 농장에 오신 것을 환영합니다. \r\n이곳에서는 다양한 농작물을 기르고 수확할 수 있습니다. \r\n먼저, 테이블에 놓인 괭이를 집어 울타리 안쪽의 땅을 갈아 보세요.\r\n3,4번 정도 괭이를 내려 치면 밭이 생깁니다. ";
            checkstep = 0;
            audio.Play();
            curtime = 0;

        }
        else if(checkstep == 1 && step == 1)
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
            audio.clip = tts2;
            textTitle.text = "그 다음엔 오른쪽에 놓인 토마토 줄기를\r\n갈아 놓은 밭에 심어 보세요.";
            checkstep = 0;
            audio.Play();
            curtime = 0;
        }
        else if (checkstep == 1 && step == 2)
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
            audio.clip = tts3;
            textTitle.text = "밭에 토마토를 심었다면, 테이블에 놓인 물통을 집어서\r\n토마토에 물을 주세요. 물을 주기 전까지는 자라지 않습니다.";
            checkstep = 0;
            audio.Play();
            curtime = 0;

        }
        else if (checkstep == 1 && step == 3)
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
            audio.clip = tts4;
            textTitle.text = "다 자란 토마토를 집어서 바구니에 담아 보세요.\r\n테이블에 놓인 낫을 사용해서 토마토 줄기를 베고 \r\n떨어진 토마토들을 주워 담아도 됩니다. \r\n낫으로 토마토 줄기를 베면 잠시 후 그 토마토 줄기는 사라지게 됩니다. \r\n\r\n더 많은 작물을 심고 수확해 보세요. ";
            checkstep = 0;
            step = 4;
            curtime = 0;
            audio.Play();

            
        }
        if(step == 4 && curtime >60)
        {
            textTitle.text = "";
        }
        
    }
}
