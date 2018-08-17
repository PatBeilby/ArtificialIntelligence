using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CTRL + K + D
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public Rigidbody rigid;
    public float rayDistance = 1f;

    //private int jumps = 0;

  private bool isGrounded = true;

    private void OnDrawGizmosSelected()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);

    }

    bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(groundRay, out hit, rayDistance))
        {
            return true;
        
        }
        return false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal") * moveSpeed;
        float inputV = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 moveDir = new Vector3(inputH, 0f, inputV);

        Vector3 force = new Vector3(moveDir.x, rigid.velocity.y, moveDir.z);

        if(Input.GetButton("Jump") && IsGrounded())
        {
            force.y = jumpHeight;
        }

        rigid.velocity = force;

        if(moveDir.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        // Rigidbody code..
        #region
        /*
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forward = new Vector3(0, 0, 1);
            rigid.AddForce(Vector3.forward * moveSpeed);
        }
        // Move Back
        if (Input.GetKey(KeyCode.S))
        {

            rigid.AddForce(Vector3.back * moveSpeed);
        }

        // Move left Key Check
        if (Input.GetKey(KeyCode.A))
        {

            rigid.AddForce(Vector3.left * moveSpeed);
        }

        // Move right Key Check

        if (Input.GetKey(KeyCode.D))
        {

            rigid.AddForce(Vector3.right * moveSpeed);
        }

        // Jump Key Check
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded = false) && (jumps <= 2))
        {
            jumps++;
            rigid.AddForce(Vector3.forward * jumpHeight, ForceMode.Impulse);
        }

    */
        #endregion

    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
   /*
 private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.name != "Ground"))
        {
            isGrounded = false;
        }
       
            if (collision.collider.name == "Ground")
        {
            isGrounded = true;
            jumps = 0;
        }

    }
    */
}
     

