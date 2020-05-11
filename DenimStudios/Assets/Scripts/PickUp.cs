using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform TheDest;
    public GameObject eggParent;
    public bool pickedUp;
    public CharMove Player;

    void Start()
    {
        pickedUp = false;
    }

    void OnTriggerStay(Collider egg)
    {
        if (egg.gameObject.tag == "Player")
        {
            if (pickedUp == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("pickup");
                    eggParent.GetComponent<CapsuleCollider>().enabled = false;
                    eggParent.GetComponent<Rigidbody>().useGravity = false;
                    eggParent.transform.position = TheDest.position;
                    eggParent.GetComponent<Rigidbody>().isKinematic = true;
                    eggParent.transform.parent = GameObject.Find("Destination").transform;
                    pickedUp = true;
                    Player.canJump = false;
                    Player.speed /= 1.5f;
                }
            }
            else
            {
                Debug.Log("loss?");
                if (Input.GetKeyDown(KeyCode.G))
                {
                    Debug.Log("loss!");
                    eggParent.transform.parent = null;
                    eggParent.GetComponent<CapsuleCollider>().enabled = true;
                    eggParent.GetComponent<Rigidbody>().useGravity = true;
                    eggParent.GetComponent<Rigidbody>().isKinematic = false;
                    eggParent.transform.position = new Vector3(TheDest.position.x + 2, TheDest.position.y, TheDest.position.z);
                    pickedUp = false;
                    Player.canJump = true;
                    Player.speed *= 1.5f;
                }
            }
        }

    }
}
