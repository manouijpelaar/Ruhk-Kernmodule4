using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform TheDest;
    public GameObject eggParent;
    public bool pickedUp;
    public CharacterController2D Player;
    public PlayerMovement Movement;

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
                    eggParent.GetComponent<CapsuleCollider>().enabled = false;
                    eggParent.GetComponent<Rigidbody>().useGravity = false;
                    eggParent.transform.position = TheDest.position;
                    eggParent.GetComponent<Rigidbody>().isKinematic = true;
                    eggParent.transform.parent = GameObject.Find("Destination").transform;
                    pickedUp = true;
                    Player.GetComponent<CharacterController2D>().jumpVelocity = 0;
                    Movement.GetComponent<PlayerMovement>().runSpeed /= 1.5f;
                    Debug.Log("pickup");
                }
            }

            else
            {
                
                if (Input.GetKeyDown(KeyCode.G))
                {
                    eggParent.transform.parent = null;
                    eggParent.GetComponent<CapsuleCollider>().enabled = true;
                    eggParent.GetComponent<Rigidbody>().useGravity = true;
                    eggParent.GetComponent<Rigidbody>().isKinematic = false;
                    eggParent.transform.position = new Vector3(TheDest.position.x + 2, TheDest.position.y, TheDest.position.z);
                    pickedUp = false;
                    Player.GetComponent<CharacterController2D>().jumpVelocity = 15;
                    Movement.GetComponent<PlayerMovement>().runSpeed *= 1.5f;
                    Debug.Log("loss!");
                }
            }
        }

    }
}
