using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class makemud : MonoBehaviour
{
    // Start is called before the first frame update
    int isup;
    void Start()
    {
        isup = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //curtime += Time.deltaTime;
        if (transform.Find("rakepoint").gameObject.transform.position.y > 0.6)
        {
            isup = 1;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isup == 1 && collision.gameObject.CompareTag("mudarea"))
        {
            isup = 0;
            if (collision.GetComponent<checkmud>().count<3)
            {
                collision.GetComponent<checkmud>().count += 1;
            }
        }
    }
}
