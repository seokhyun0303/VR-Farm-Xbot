using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zbcollision : MonoBehaviour
{

    public Animator animator;   
    void Start()
    {
        animator.SetBool("ishit", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("wp")) {
            score.curscore += 1;
            Destroy(this.gameObject);
        }
    }
}
