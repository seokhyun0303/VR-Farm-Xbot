using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < 0)
        {
            Vector3 v = transform.position;
            transform.position = new Vector3(v.x, 0.1f, v.z);
        }
    }
}
