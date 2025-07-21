using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcanicontrol : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject text;
    public Animator animator;
    void Start()
    {
        text = GameObject.Find("Text (TMP)");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(text.GetComponent<npctext>().step == 1)
        {
            animator.SetInteger("setani", 1);
        }
        if (text.GetComponent<npctext>().step == 2)
        {
            animator.SetInteger("setani", 2);
        }
        if (text.GetComponent<npctext>().step == 3)
        {
            animator.SetInteger("setani", 3);
        }
        if (text.GetComponent<npctext>().step == 4)
        {
            animator.SetInteger("setani", 4);
        }

    }
}
