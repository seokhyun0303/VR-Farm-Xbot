using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterparticle : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject textstep;
    void Start()
    {
        textstep = GameObject.Find("Text (TMP)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("plant") && other.GetComponent<grow>().inmud == 1)
        {
            other.GetComponent<grow>().inmud = 2;
            other.GetComponent<grow>().plantcurtime = 0;
            other.GetComponent<MeshCollider>().isTrigger = true;
            if (textstep.GetComponent<npctext>().checkstep == 0 && textstep.GetComponent<npctext>().step == 2)
            {
                textstep.GetComponent<npctext>().checkstep = 1;
                textstep.GetComponent<npctext>().step = 3;
            }
        }
    }
}
