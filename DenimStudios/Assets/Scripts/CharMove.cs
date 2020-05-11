using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    [Range (1f, 10f)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody rb;
    public float speed = 8f;
    //public float jumpPower = 11f;

    public bool IsLookingLeft = true;
    public bool isGrounded;
    public bool canJump;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>();

        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(hori, 0, vert);

        if(hori < 0 && !IsLookingLeft)
        {
            IsLookingLeft = true;
            transform.Rotate(Vector3.up, -180);
        }
        else if (hori >= 0 && IsLookingLeft)
        {
            IsLookingLeft = false;
            transform.Rotate(Vector3.up, 180);
        }

        if((hori != 0 || vert != 0) )
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        transform.position += move * Time.deltaTime * speed;
        //rb.AddForce(move * speed);
    }

    void FixedUpdate()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump") && canJump)
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
            //rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            anim.SetBool("jump", true);
            
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

  bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                isGrounded = true;
                return true;
            }
        }
        isGrounded = false;
        return false;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("jump", false);
        }
    }
}
