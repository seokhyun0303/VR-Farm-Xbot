using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishplant : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject veg, fru1, fru2, fru3;
    Rigidbody m_Rigidbody;
    float curtime;
    int iscut;
    void Start()
    {
        gameObject.GetComponent<MeshCollider>().isTrigger = false;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        veg = Resources.Load("Tomato_03") as GameObject;
        fru1 = Instantiate(veg);
        fru1.transform.position = transform.Find("tpose1").gameObject.transform.position;
        fru2 = Instantiate(veg);
        fru2.transform.position = transform.Find("tpose2").gameObject.transform.position;
        fru3 = Instantiate(veg);
        fru3.transform.position = transform.Find("tpose3").gameObject.transform.position;
        curtime = 0;
        iscut = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        if(iscut == 1 && curtime > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("sickle"))
        {
            m_Rigidbody.constraints = RigidbodyConstraints.None;
            fru1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            fru2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            fru3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            curtime = 0;
            iscut = 1;
        }
    }
}
