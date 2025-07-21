using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkmud : MonoBehaviour
{
    // Start is called before the first frame update
    public int count;
    //int shvcount;
    GameObject md, mud, textstep;
    void Start()
    {
        count = 0;
        //shvcount = 0;
        md = Resources.Load("Mud_01") as GameObject;
        textstep = GameObject.Find("Text (TMP)");
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            mud = Instantiate(md);
            mud.transform.position = transform.position;
            count = 4;
            if(textstep.GetComponent<npctext>().checkstep == 0 && textstep.GetComponent<npctext>().step == 0)
            {
                textstep.GetComponent<npctext>().checkstep = 1;
                textstep.GetComponent<npctext>().step = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("shovel"))
        {
            Destroy(mud);
        }
    }


}
