using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
/*
 * this class is just a data container for the newly created gameobject('s) 
 * It is here so we can load multiple objects instad of loading just one. 
 */
namespace XRFinalProject
{
    public class LoadedObjData : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider boxCollider;
        [SerializeField]
        private Rigidbody rb;
        [SerializeField]
        private XRGrabInteractable grapInteractable;

        [SerializeField]
        private GameObject thisGameObject;

        private void Awake()
        {
            //reference to this Gameobject. 
            thisGameObject = this.gameObject;
            thisGameObject.transform.localScale = new Vector3(0.2f,0.2f, 0.2f);
            thisGameObject.AddComponent<BoxCollider>();
            thisGameObject.AddComponent<Rigidbody>();
            thisGameObject.AddComponent<XRGrabInteractable>();

            boxCollider = GetComponent<BoxCollider>();
            rb = GetComponent<Rigidbody>();
            grapInteractable = GetComponent<XRGrabInteractable>();
            afterLoading();

        }

        private async Task afterLoading()
        {
            await Task.Delay(100);
            Mesh mesh = GetComponentInChildren<MeshFilter>().mesh;
            Bounds bounds = mesh.bounds;
            boxCollider.size = bounds.size;
            boxCollider.center = bounds.center;

        }
    } 
}
