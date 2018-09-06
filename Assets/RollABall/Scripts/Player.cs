using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class Player : MonoBehaviour
    {

        public float moveSpeed = 5f;
        public float jumpHeight = 10f;
        public Rigidbody rigid;
        public float rayDistance = 1f;

        private bool isGrounded = true;

        // Implement this OnDrawGizmosSelected if you want to draw gizmos only if the object is selected
        private void OnDrawGizmos()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
        }

        bool IsGrounded()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            // cast a line beneath the player
            if (Physics.Raycast(groundRay, out hit, rayDistance))
            {
                // return true if grounded
                return true;
            }
            // return false if not grounded
            return false;
        }

        private void Update()
        {

            // asking for GetAxis gives you a float value returned
            float inputH = Input.GetAxis("Horizontal") * moveSpeed;
            float inputV = Input.GetAxis("Vertical") * moveSpeed;
            Vector3 moveDir = new Vector3(inputH, 0f, inputV);
            Vector3 force = new Vector3(moveDir.x, rigid.velocity.y, moveDir.z);

            // asking for getkeydown gives you a bool vlaue - its either true or false
            if (Input.GetButton("Jump") && IsGrounded())
            {
                force.y = jumpHeight;
            }
            rigid.velocity = force;

            if (moveDir.magnitude > 0)
            {
                // rotate the player to that moveDir
                transform.rotation = Quaternion.LookRotation(moveDir);
            }

        }

        // Update is called once per frame
        /*void Update () {

            // check if W key is pressed, 
            if (Input.GetKey(KeyCode.W))
            {
                // declare and definition/ assigning the value
                Vector3 forward = new Vector3(0, 0, 1);

                //if true then move forward
                ridge.AddForce(forward *movespeed);
                //another way to write the above
                // ridge.AddForce(Vector3.forward * speed);

            }

            // check if s is pressed
            if (Input.GetKey(KeyCode.S))
            {
                // if true, move back
                ridge.AddForce(Vector3.back * movespeed);

            }


            //check if A is pressed
            if (Input.GetKey(KeyCode.A))
            {
                // if true, move left
                ridge.AddForce(Vector3.left * movespeed);

            }

            // check if d is pressed
            if (Input.GetKey(KeyCode.D))
            {
                // if true, move right
                ridge.AddForce(Vector3.right * movespeed);

            }

            // if space bar is pressed and the player is grounded, jump up
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                ridge.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
            }

        }*/

        // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
        /*private void OnCollisionEnter(Collision collision)
        {
            // when the object has hit something
            if (collision.collider.name == "Ground")
            {
                // i have hit an object
                isGrounded = true;
            }
        }*/
    }
}