using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dummiesman;


/*
 * this script here handles the object laoding it self. 
 * It takes the ID from list of the files in the specified directory and 
 * loads the file you choose. 
 * THE FILE CHOSEN MUST BE .obj file other wise this will give and error. 
 */
namespace XRFinalProject
{
    public class LoadObject : MonoBehaviour
    {
        //Variables needed for the scirpt to work. 
        private int objListId;
        private string objToLoadFolderPath;
        [SerializeField]
        private TMP_Dropdown dropDownMenu;

        //This is the object we will load. 
        public GameObject objToLoad;

        public void UpdateModelToLoad()
        {
            objListId = dropDownMenu.value;

            objToLoadFolderPath = FolderContentListing.filesList[objListId];
            //Debug.Log(objToLoadFolderPath);
        }

        public void LoadObjFromPath()
        {
            useOBJLoader();
        }

        //This function is the one that actually loads the files into your game. 
        private void useOBJLoader()
        {
            objToLoad = new OBJLoader().Load(objToLoadFolderPath);
            objToLoad.AddComponent<LoadedObjData>();
            //once the game object is loaded we don't need reference to  that instance of it again here. 
            objToLoad = null;
            //Debug.Log(objToLoad.name);
        }


    } 
}
