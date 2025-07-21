using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watercan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waterp,wp;
    Vector3 p1, p2;
    void Start()
    {
        waterp = Resources.Load("waterparticle") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
       p1 = transform.Find("wcpos1").gameObject.transform.position;
       p2 = transform.Find("wcpos2").gameObject.transform.position;
        if (p1.y <= p2.y)
        {
            wp = Instantiate(waterp);
            wp.transform.position = p1;
        }
    }
}


