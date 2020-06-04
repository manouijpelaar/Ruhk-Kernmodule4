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
        Movement.GetComponent<PlayerMovement>().pickedUpObject = false;
    }

    void OnTriggerStay(Collider egg)
    {
        if (egg.gameObject.tag == "Player")
        {
            if (pickedUp == false && Movement.GetComponent<PlayerMovement>().pickedUpObject == false)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    eggParent.GetComponent<CapsuleCollider>().enabled = false;
                    eggParent.GetComponent<Rigidbody>().useGravity = false;
                    eggParent.transform.position = TheDest.position;
                    eggParent.GetComponent<Rigidbody>().isKinematic = true;
                    eggParent.transform.parent = GameObject.Find("Destination").transform;
                    pickedUp = true;
                    Movement.GetComponent<PlayerMovement>().pickedUpObject = true;
                    Player.GetComponent<CharacterController2D>().jumpVelocity = 0;
                    Movement.GetComponent<PlayerMovement>().runSpeed /= 1.5f;
                    Debug.Log("pickup");
                }
            }

            else
            {
                if (pickedUp == true && Movement.GetComponent<PlayerMovement>().pickedUpObject == true)
                {
                    if (Input.GetKeyDown(KeyCode.K))
                    {
                        Movement.GetComponent<PlayerMovement>().runSpeed *= 1.5f;
                        Player.GetComponent<CharacterController2D>().jumpVelocity = 15;
                        eggParent.transform.parent = null;
                        eggParent.GetComponent<CapsuleCollider>().enabled = true;
                        eggParent.GetComponent<Rigidbody>().useGravity = true;
                        eggParent.GetComponent<Rigidbody>().isKinematic = false;

                        if (Player.m_FacingRight == true)
                        {
                            eggParent.transform.position = new Vector3(TheDest.position.x + 2, TheDest.position.y + 1, TheDest.position.z);

                        }
                        if (Player.m_FacingRight == false)
                        {
                            eggParent.transform.position = new Vector3(TheDest.position.x - 2, TheDest.position.y + 1, TheDest.position.z);
                        }

                        pickedUp = false;
                        Movement.GetComponent<PlayerMovement>().pickedUpObject = false;
                        Debug.Log("loss!");
                    }
                }
            }
        }

    }
}
