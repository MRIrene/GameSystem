using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Practice
{
    public class CameraOrbit : MonoBehaviour
    {


        public Transform target;
        public bool hideCursor = true;
        [Header("Orbit")]
        public Vector3 offset = new Vector3(0, 5f, 0);
        public float xSpeed = 120f;     //x orbit speed
        public float ySpeed = 120f;     //y orbit speed
        public float yMinLimit = -20f;
        public float yMaxLimit = 80f;
        public float distanceMin = 0.5f; // min distance to target
        public float distanceMax = 15f;  // max distance to target

        [Header("Collision")]
        public bool cameraCollision = true;     //is cam collision
        public float camRadius = 0.3f;      //radius of cam collision cast
        public LayerMask ignoreLayers;      // layers ignored by collision

        public Vector3 originalOffset; //original offset at start of game
        private float distance;     //current distance to camera
        private float rayDistance = 1000f; //max distance ray can check of collisions
        private float x = 0f;   //x degrees of rotation
        private float y = 0f;   //y degrees of rotation



        // Use this for initialization
        void Start()
        {

            // detach camera from parent
            transform.SetParent(null);
            // set target
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            // is the cursor supposed to be hidden?
            if (hideCursor) // if hide cursor is true
            {
                //lock..
                Cursor.lockState = CursorLockMode.Locked;
                // hide the cusror 
                Cursor.visible = false;
            }
            // Calculate original offset from target position
            originalOffset = transform.position - target.position;
            // set ray distance to current distance magitude of camera
            rayDistance = originalOffset.magnitude;
            //get camera rotation
            Vector3 angles = transform.eulerAngles;
            //set x and y degrees to current camera rotation
            x = angles.y;
            y = angles.x;

        }
        // Update is called once per frame
        void FixedUpdate()
        {
            //if a target has been set
            if (target)
            {
                //is camera collision enabled?
                if (cameraCollision)
                {
                    //create a ray starting from targets position and point backwards towards camera
                    Ray camRay = new Ray(target.position, transform.forward);
                    RaycastHit hit;
                    //shoot a sphere in a defined ray direction
                    if (Physics.SphereCast(camRay, camRadius, out hit, rayDistance, ~ignoreLayers, QueryTriggerInteraction.Ignore))
                    {
                        // set current camera distance to hit objects distance
                        distance = hit.distance;
                        //exit function
                        return;
                    }
                }
                // set distance to origninal distance
                distance = originalOffset.magnitude;

            }
        }

        private void Update()
        {
            //if target has been set
            if (target)
            {
                //rotate the camera based on Mouse x and Mouse Y inputs
                x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
                y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
                //clamp the angle using the custom 'ClampAngle' function
                y = ClampAngle(y, yMinLimit, yMaxLimit);
                //rotate the transform using euler angles (y for x and x for y)
                transform.rotation = Quaternion.Euler(y, x, 0);
            }
        }

        void LateUpdate()
        {
            if (target)
            {
                //calculate our local offset from offset
                Vector3 localOffset = transform.TransformDirection(offset);
                //resposition camera to new position based off distance and offset
                transform.position = (target.position + localOffset) + -transform.forward * distance;
            }
        }
        // clamps the angle between -360 and 360 degrees and using the 
        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360f)
            {
                angle += 360;
            }
            if (angle > 360f)
            {
                angle -= 360;
            }
            return Mathf.Clamp(angle, min, max);
        }
    }
}