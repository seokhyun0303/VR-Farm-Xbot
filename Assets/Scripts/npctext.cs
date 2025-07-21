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
            textTitle.text = "VR ���忡 ���� ���� ȯ���մϴ�. \r\n�̰������� �پ��� ���۹��� �⸣�� ��Ȯ�� �� �ֽ��ϴ�. \r\n����, ���̺� ���� ���̸� ���� ��Ÿ�� ������ ���� ���� ������.\r\n3,4�� ���� ���̸� ���� ġ�� ���� ����ϴ�. ";
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
            textTitle.text = "�� ������ �����ʿ� ���� �丶�� �ٱ⸦\r\n���� ���� �翡 �ɾ� ������.";
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
            textTitle.text = "�翡 �丶�並 �ɾ��ٸ�, ���̺� ���� ������ ���\r\n�丶�信 ���� �ּ���. ���� �ֱ� �������� �ڶ��� �ʽ��ϴ�.";
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
            textTitle.text = "�� �ڶ� �丶�並 ��� �ٱ��Ͽ� ��� ������.\r\n���̺� ���� ���� ����ؼ� �丶�� �ٱ⸦ ���� \r\n������ �丶����� �ֿ� ��Ƶ� �˴ϴ�. \r\n������ �丶�� �ٱ⸦ ���� ��� �� �� �丶�� �ٱ�� ������� �˴ϴ�. \r\n\r\n�� ���� �۹��� �ɰ� ��Ȯ�� ������. ";
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
