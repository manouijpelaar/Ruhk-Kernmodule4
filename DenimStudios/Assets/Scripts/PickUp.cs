using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform TheDest;

    public bool pickedUp;
    public bool pickedUpObject;

    public bool StartTime = false;
    public float TimeStamp = 2;

    public CharacterController2D Player;
    public PlayerMovement Movement;

    public Collider Egg;

    void Start()
    {
        pickedUp = false;
        pickedUpObject = false;
        TimeStamp -= Time.deltaTime;
        //Destination = TheDest.position = Object.transform.position;
    }

    void Update()
    {
        if (StartTime)
            TimeStamp -= Time.deltaTime;

        //Neerzetten
        if (pickedUp == true && pickedUpObject == true && TimeStamp < 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Egg.GetComponent<BoxCollider>().enabled = true;
                Egg.GetComponent<Rigidbody>().useGravity = true;
                Egg.GetComponent<Rigidbody>().isKinematic = false;

                Player.GetComponent<CharacterController2D>().jumpVelocity = 15;
                Movement.GetComponent<PlayerMovement>().runSpeed *= 1.5f;
                if (Egg.transform.parent != null)
                {
                    Egg.transform.parent = null;
                }
                pickedUp = false;
                pickedUpObject = false;
            }
        }
    }

    void OnTriggerStay(Collider Object)
    {
        Debug.Log(pickedUp);
        Debug.Log(pickedUpObject);
        string Tag = Object.gameObject.tag;

        //Oppakken
        if (Tag == "Pickable" || pickedUpObject == false)
        {
            if (pickedUp == false && pickedUpObject == false)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    Egg = Object;
                    Object.GetComponent<BoxCollider>().enabled = true; 
                    Object.transform.position = TheDest.position;
                    
                    Object.transform.parent = GameObject.Find("Destination").transform;
                    StartTime = true;
                    TimeStamp = 0.1f;
                    Object.GetComponent<Rigidbody>().useGravity = false;
                    Object.GetComponent<Rigidbody>().isKinematic = true;

                    Player.GetComponent<CharacterController2D>().jumpVelocity = 0;
                    Movement.GetComponent<PlayerMovement>().runSpeed /= 1.5f;

                    pickedUp = true;
                    pickedUpObject = true;
                    Debug.Log("pickup");
                }
            }
        }
    }
}
