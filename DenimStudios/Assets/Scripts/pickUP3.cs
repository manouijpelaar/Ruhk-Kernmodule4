using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUP3 : MonoBehaviour
{
    public Transform TheDest;
    public bool handenVol;

    public bool Key;
    public CharacterController2D Player;
    public PlayerMovement Movement;
    public GameObject pickUpCollider;

    public float TimeStamp = 0;
    private GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        handenVol = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeStamp >= 0)
            TimeStamp -= Time.deltaTime;



        //Oppakken
        //============================================================
        RaycastHit hit;

        
        //welke kant kijk ik op
        //kijk ik naar rechts 
        if (Player.m_FacingRight == true)
        {
            //Raycast wordt hier uit gevoert naar rechts
            Ray ray = new Ray(transform.position, Vector3.right);
            Debug.DrawRay(transform.position, Vector3.right * 2);

            if (Physics.Raycast(ray, out hit, 2) && handenVol == false)
            {
                if (hit.collider.gameObject.GetComponent<pickable>() != null) //mag ik het object oppaken?
                {
                    if (selectedObject != hit.collider.gameObject)// is dit het opbject wat ik al vast heb?
                    {
                        if (selectedObject != null) // als ik nog geen object vast heb
                        {
                            selectedObject.gameObject.GetComponent<pickable>().selected = false;
                        }
                        selectedObject = hit.collider.gameObject; //hier wordt het opject geslecteerd 
                        selectedObject.GetComponent<pickable>().selected = true; //CALL SCRIPT HERE
                    }
                }
                else if (selectedObject != null)//niet het goede object 
                {
                    selectedObject.GetComponent<pickable>().selected = false;
                    selectedObject = null;
                }
            }
            else if (selectedObject != null)//raycast heeft niks geraakt
            {
                selectedObject.GetComponent<pickable>().selected = false;
                selectedObject = null;
            }
        }
        else //kijk ik naar links
        {
            //Raycast wordt hier uit gevoert naar links
            Ray ray = new Ray(transform.position, Vector3.left);
            Debug.DrawRay(transform.position, Vector3.left * 2);
            if (Physics.Raycast(ray, out hit, 2) && handenVol == false)
            {
                if (hit.collider.gameObject.GetComponent<pickable>() != null) //mag ik het object oppaken?
                {
                    if (selectedObject != hit.collider.gameObject)// is dit het opbject wat ik al vast heb?
                    {
                        if (selectedObject != null) // als ik nog geen object vast heb
                        {
                            selectedObject.gameObject.GetComponent<pickable>().selected = false;
                        }
                        selectedObject = hit.collider.gameObject; //hier wordt het opject geslecteerd 
                        selectedObject.GetComponent<pickable>().selected = true; // op het object wordt de material aan gepast
                    }
                }
                else if (selectedObject != null) //niet het goede object 
                {
                    selectedObject.GetComponent<pickable>().selected = false; //highlight uit
                    selectedObject = null;
                }
            }
            else if (selectedObject != null) //racast niks geraakt
            {
                selectedObject.GetComponent<pickable>().selected = false; //highlight uit 
                selectedObject = null;
            }
        }




        if (handenVol == false && TimeStamp < 0 && selectedObject != null) //-als handen leeg zijn, -cooldown klaar is & -als er iets geselecteerd is 
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)&& handenVol == false) //push
            {
                selectedObject.GetComponent<Rigidbody>().isKinematic = false;
                selectedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                Movement.GetComponent<PlayerMovement>().runSpeed /= 2f;
                Player.GetComponent<CharacterController2D>().jumpVelocity = 0;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                selectedObject.GetComponent<Rigidbody>().isKinematic = true;
                selectedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                Movement.GetComponent<PlayerMovement>().runSpeed *= 2f;
                Player.GetComponent<CharacterController2D>().jumpVelocity = 15;
            } 
          
            
            if (Input.GetKeyDown(KeyCode.E) ) // en op E wordt gedrukt 
            {
                selectedObject.transform.position = TheDest.position; //Object wordt op gepakt
                handenVol = true;
                selectedObject.GetComponent<pickable>().selected = true;
                //Parent
                selectedObject.transform.parent = TheDest;

                //pickUpCollider aan
                pickUpCollider.GetComponent<CapsuleCollider>().enabled = true;

                //colliders
                selectedObject.GetComponent<Rigidbody>().useGravity = false;
                selectedObject.GetComponent<Rigidbody>().isKinematic = true;
                selectedObject.GetComponent<MeshCollider>().isTrigger = true;

                //Player Settings
                Player.GetComponent<CharacterController2D>().jumpVelocity = 0;
                Movement.GetComponent<PlayerMovement>().runSpeed /= 1.5f;

                //KeyCode wait
                TimeStamp = 0.05f;
            }
        }
        //neerzetten
        if (handenVol == true && TimeStamp < 0)
        {

            if (Input.GetKeyDown(KeyCode.E)) // er word weer op E gedrukt
            {
                if (TheDest.childCount > 0) // Object word losgelaten
                {
                    //Rigidbody
                    TheDest.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                    TheDest.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                    TheDest.GetChild(0).GetComponent<MeshCollider>().isTrigger = false;

                    //Deparent
                    TheDest.GetChild(0).parent = null;

                    //Player settings
                    Player.GetComponent<CharacterController2D>().jumpVelocity = 15;
                    Movement.GetComponent<PlayerMovement>().runSpeed *= 1.5f;

                    //pickUpCollider uit
                    pickUpCollider.GetComponent<CapsuleCollider>().enabled = false;

                    handenVol = false;

                    //KeyCode wait
                    TimeStamp = 0.05f;
                }
            }
        }
    }
}





