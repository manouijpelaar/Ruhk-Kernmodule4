using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLauch : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider launch)
    {   // when player collides with winscene, level complete
        if (launch.gameObject.tag == "LauchBox" && GameObject.FindWithTag("Approval").GetComponent<LauchApproval>().ready == true)
        {
            rb.AddForce(transform.up * 700 + transform.forward * 260);


        }

    }
}
