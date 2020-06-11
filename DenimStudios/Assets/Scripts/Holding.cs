using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour
{
    /*public Transform TheDest;
    public GameObject Object;

    public bool pickedUp;

    public CharacterController2D Player;
    public PlayerMovement Movement;

    void Start()
    {
        pickedUp = false;
        //Movement.GetComponent<PlayerMovement>().pickedUpObject = false;
    }

    void OnTriggerStay(Collider egg)
    {
        //if (egg.gameObject.tag == "Player" || Movement.GetComponent<PlayerMovement>().pickedUpObject == true)
        //{
        //    if (pickedUp == false && Movement.GetComponent<PlayerMovement>().pickedUpObject == false)
        //    {
        //        if (Input.GetKeyUp(KeyCode.K))
        //        {
        //            //Object.GetComponent<BoxCollider>().enabled = false;
                    Object.GetComponent<Rigidbody>().useGravity = false;
                    Object.transform.position = TheDest.position;
                    Object.GetComponent<Rigidbody>().isKinematic = true;
                    Object.transform.parent = GameObject.Find("Destination").transform;
                    pickedUp = true;
                    Movement.GetComponent<PlayerMovement>().pickedUpObject = true;
                    Player.GetComponent<CharacterController2D>().jumpVelocity = 0;
                    Movement.GetComponent<PlayerMovement>().runSpeed /= 1.5f;
                    Debug.Log("pickup");
                }
            }

            else
            {
                if (pickedUp == true && Movement.GetComponent<PlayerMovement>().pickedUpObject == true && Movement.GetComponent<PlayerMovement>().DropAble == true)
                {
                    if (Input.GetKeyDown(KeyCode.K))
                    {
                        Movement.GetComponent<PlayerMovement>().runSpeed *= 1.5f;
                        Player.GetComponent<CharacterController2D>().jumpVelocity = 15;
                        Object.transform.parent = null;
                        //Object.GetComponent<BoxCollider>().enabled = true;
                        Object.GetComponent<Rigidbody>().useGravity = true;
                        Object.GetComponent<Rigidbody>().isKinematic = false;

                        if (Player.m_FacingRight == true)
                        {
                            Object.transform.position = new Vector3(TheDest.position.x, TheDest.position.y, TheDest.position.z);

                        }
                        if (Player.m_FacingRight == false)
                        {
                            Object.transform.position = new Vector3(TheDest.position.x, TheDest.position.y, TheDest.position.z);
                        }

                        pickedUp = false;
                        Movement.GetComponent<PlayerMovement>().pickedUpObject = false;
                        Debug.Log("loss!");
                    }
                }
            }
        }

    }*/
}
