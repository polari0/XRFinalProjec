using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

namespace XRFinalProject
{
    public class FolderContentListing : MonoBehaviour
    {
        /*
         * This script simply checks if folder path has been unpated by GetFolderPath class 
         * if it has been updated it lists the folder contents to a drowdownMenu
         * To be added exeption handleding in the case updated folder path in invalid. 
        */
        public static string folderPath = "Please Change folder path to desired location";
        public static bool folderPathUpdated = false;

        [SerializeField]
        private TMP_Dropdown dropDownMenuFileList;



        [SerializeField]
        private TMP_InputField pathInput;

        public static List<string> filesList;
        public static List<string> fileNames;
        public void LoadFolderContents()
        {
            GetNewFolderPath();
            //Debug.Log("we got here");
            if (folderPathUpdated)
            {
                filesList = new List<string>(Directory.GetFiles(folderPath));
                fileNames = new List<string>();
                foreach (string file in filesList)
                {
                    fileNames.Add(Path.GetFileName(file)); //Gets just the file name istead of the full path. 
                    //Debug.Log(file);
                }
                dropDownMenuFileList.ClearOptions();
                dropDownMenuFileList.AddOptions(fileNames);
            }
            else if(!folderPathUpdated) Debug.Log(folderPath);
        }
        //This gets the newly imputed folder path and checks that is has been updated.
        public void GetNewFolderPath()
        {
            if (pathInput.text != null)
            {
                folderPathUpdated = true;
                folderPath = pathInput.text;
                //Debug.Log(FolderLoading.folderPath); 
            }
            else pathInput.text = "please add the desired folder path here";
        }
    } 
}
