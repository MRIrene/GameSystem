﻿using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//CheckPoint
namespace RollABall
{
    public class CheckPoint : MonoBehaviour
    {
        #region Variables
        [Header("Check Point Elements")]
        //GameObject for our currentCheck
        public GameObject curCheckpoint;
        [Header("Character Handler")]
        //character handler script that holds the players health
        public CharacterHandler charH;
        #endregion
        #region Start
        //the character handler is the component attached to our player
        #region Check if we have Key
        //if we have a save key called SpawnPoint
        //then our checkpoint is equal to the game object that is named after our save file
        //our transform.position is equal to that of the checkpoint
        #endregion
        #endregion
        #region Update
        //if our characters health is less than or equal to 0
        //our transform.position is equal to that of the checkpoint
        //our characters health is equal to full health
        //character is alive
        //characters controller is active		
        #endregion
        #region OnTriggerEnter
        //Collider other
        //if our other objects tag when compared is CheckPoint
        //our checkpoint is equal to the other object
        //save our SpawnPoint as the name of that object
        #endregion
    }
}


