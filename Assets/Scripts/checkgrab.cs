using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class checkgrab : MonoBehaviour
{
    // Start is called before the first frame update
    private HandGrabInteractable _interactable;
    void Start()
    {
        _interactable = gameObject.GetComponent<HandGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {

        var hand = _interactable.Interactors.FirstOrDefault<HandGrabInteractor>();
        if (hand != null)
        {
            Destroy(gameObject);
        }
    }
}
