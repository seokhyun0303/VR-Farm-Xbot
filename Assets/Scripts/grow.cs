using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 thispos;
    public int inmud = 0;
    public float plantcurtime;
    float pretime;
    public GameObject fplant;
    Rigidbody m_Rigidbody;
    GameObject textstep;

    void Start()
    {
        plantcurtime = 0;
        pretime = 0;
        fplant = Resources.Load("Tomato_Plant_finish") as GameObject;
        m_Rigidbody = GetComponent<Rigidbody>();
        textstep = GameObject.Find("Text (TMP)");
    }

    // Update is called once per frame
    void Update()
    {
        plantcurtime += Time.deltaTime;
        if(inmud == 1) { 
            transform.position = thispos;
            transform.rotation = Quaternion.identity;
        }
        if (inmud == 2)
        {
            transform.position = thispos;
            transform.rotation = Quaternion.identity;
            if (plantcurtime - pretime > 2)
            {
                transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                pretime = plantcurtime;
            }
            if (plantcurtime > 10)
            {
                GameObject fp = Instantiate(fplant);
                fp.transform.position = thispos;
                fp.transform.localScale = this.transform.localScale;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    { 
        if (inmud == 0 && collision.gameObject.CompareTag("mud"))
        {
            thispos = collision.transform.position;
            inmud = 1;
            if (textstep.GetComponent<npctext>().checkstep == 0 && textstep.GetComponent<npctext>().step == 1)
            {
                textstep.GetComponent<npctext>().checkstep = 1;
                textstep.GetComponent<npctext>().step = 2;
            }
        }
    }
}
