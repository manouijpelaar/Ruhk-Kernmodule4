using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noClip : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider noclip)
    {
        Debug.Log("STOOOOOOP");
        if (noclip.gameObject.tag == "NotClipping")
        {
            //Player.GetComponent<PickUp>().noclip = true;
        }

    }
    void OnTriggerExit(Collider noclip)
    {
        if (noclip.gameObject.tag == "NotClipping")
        {
            //Player.GetComponent<PickUp>().noclip = false;
        }

    }
}
