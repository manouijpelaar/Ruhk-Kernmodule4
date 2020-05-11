using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPush : MonoBehaviour
{
    public bool isPushed = false;
    public float pushPower = 200f;

    void OnCollisionEnter(Collision collision)
    {
        if (!isPushed)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(transform.forward * pushPower);
            isPushed = true;
        }
    }

}
