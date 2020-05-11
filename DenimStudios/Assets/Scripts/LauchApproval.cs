using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauchApproval : MonoBehaviour
{
    public bool ready;

    void Start()
    {
        ready = false;
    }

    void OnTriggerEnter(Collider Approval)
    {   // when player collides with winscene, level complete
        if (Approval.gameObject.tag == "Player")
        {
            ready = true;
        }

    }

    void OnTriggerExit(Collider Approval)
    {   // when player collides with winscene, level complete
        if (Approval.gameObject.tag == "Player")
        {
            ready = false;
        }

    }
}
