using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLauch : MonoBehaviour
{
    public Rigidbody rb;
    public Animator launchAnm;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        launchAnm.SetBool("launch", false);
    }

    void OnTriggerEnter(Collider launch)
    {   // when player collides with winscene, level complete
        if (launch.gameObject.tag == "LauchBox" && GameObject.FindWithTag("Approval").GetComponent<LauchApproval>().ready == true)
        {
            //rb.AddForce(transform.up * 700 + transform.forward * 260);
            launchAnm.SetBool("launch", true);

        }

    }
}
