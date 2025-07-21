using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class monsterspawn : MonoBehaviour


{
    public GameObject msprefab;
    float currTime;

    void Start()
    {
        msprefab = Resources.Load("Zombie1") as GameObject;
    }


    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > 5)
        {
            float newX = 0;
            float newZ = 0;
            while((newX<10 && newX>-10) && (newZ<10 && newZ > -10))
            {
                newX = Random.Range(-50f, 50f);
                newZ = Random.Range(-50f, 50f);
            }


            //GameObject monster = Instantiate(msprefab);


            //monster.transform.position = new Vector3(newX, -1.5f, newZ);


            currTime = 0;
        }
    }
}
