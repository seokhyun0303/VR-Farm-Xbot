using Oculus.Interaction.Grab;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;
using System.Linq;

public class getveg : MonoBehaviour
{
    float curtime;
    int isgrab;
    private HandGrabInteractable _interactable;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        isgrab = 0;
        curtime = 0;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        _interactable = gameObject.GetComponent<HandGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        if (isgrab == 0)
        {
            var hand = _interactable.Interactors.FirstOrDefault<HandGrabInteractor>();
            if (hand != null)
            {
                curtime = 0;
                isgrab = 1;
            }
        }
        if (isgrab == 1)
        {
            if(curtime > 0.5f)
            {
                m_Rigidbody.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
