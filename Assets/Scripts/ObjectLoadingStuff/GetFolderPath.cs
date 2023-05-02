using UnityEngine;
using TMPro;

namespace XRFinalProject
{
    public class GetFolderPath : MonoBehaviour
    {

        //This script simply takes the input from TMP input field and changes folderpath variable to the inputed text
        public string editableFolderPath;

        [SerializeField]
        private TMP_InputField pathInput;

        public void GetNewFolderPath()
        {
            FolderContentListing.folderPathUpdated = true;
            FolderContentListing.folderPath = pathInput.text;
            //Debug.Log(FolderLoading.folderPath);
        }

    } 
}
