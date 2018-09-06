using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Practice
{
    public class CameraSurveillance : MonoBehaviour
    {

        public Camera[] cameras; // arrary of cameras to switch between
        public KeyCode prevKey = KeyCode.Q; // filter back to previous cam
        public KeyCode nextKey = KeyCode.E; // filter forward to next cam
        private int camIndex;               //current cam index from array
        private int camMax;                 //max amount of cams in array
        private Camera current; // the current camera selected



        // Use this for initialization
        void Start()
        {
            // Get all Camera children and store into array
            cameras = GetComponentsInChildren<Camera>();
            //Last index of arrary = Array.Length -1
            camMax = cameras.Length - 1;//Activate the default camera;
            ActivateCamera(camIndex);

        }

        void ActivateCamera(int camIndex)
        {
            //loop through all surveillance cameras
            for (int i = 0; i < cameras.Length; i++)
            {
                Camera cam = cameras[i];
                //if the current index matches the argument camIndex
                if (i == camIndex)
                {
                    //enable this camera
                    cam.gameObject.SetActive(true);
                }
                else // otherwise
                {
                    //disable camera
                    cam.gameObject.SetActive(false);
                }
            }
        }
        // Update is called once per frame
        void Update()
        {
            // if the next key is pressed
            if (Input.GetKeyDown(nextKey))
            {
                //increase index
                camIndex++;
                if (camIndex >= camMax)
                {
                    camIndex = 0;
                }
                ActivateCamera(camIndex);
            }
            // if the previous key is pressed
            if (Input.GetKeyDown(prevKey))
            {
                //decrease index
                camIndex--;
                //If camIndex is below zero
                if (camIndex < 0)
                {
                    //set cam to last one in array
                    camIndex = camMax;
                }
                //Active camera
                ActivateCamera(camIndex);
            }
        }
    }
}