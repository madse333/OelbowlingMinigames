using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabScript : MonoBehaviour
{
    [SerializeField] private CharacterController characterControllerScript;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool maxGrabCapacity = false;
    private FixedJoint fj;
    private GameObject grabbedObject;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (characterControllerScript.getGrab() && !maxGrabCapacity && collision.gameObject.tag != "Ground" && collision.gameObject.GetComponentInParent<CharacterController>() != characterControllerScript)
        {
            grabbedObject = collision.gameObject;
            fj = collision.gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = rb;
            maxGrabCapacity = true;
            if (grabbedObject.gameObject.tag == "Spear")
            {
                grabbedObject.GetComponent<SpearController>().enabled = false;
                grabbedObject.GetComponent<SpearController>().setGrabbed(true);
                grabbedObject.GetComponent<SpearController>().setThrower(this.gameObject.GetComponentInParent<CharacterController>());
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (maxGrabCapacity)
            {
                if (fj != null)
                {
                    Destroy(fj);
                }
                
                if (grabbedObject != null)
                {
                    if (grabbedObject.gameObject.tag == "Spear")
                    {
                        grabbedObject.GetComponent<SpearController>().enabled = true;
                        grabbedObject.GetComponent<SpearController>().setGrabbed(false);
                        grabbedObject.GetComponent<SpearController>().setTimer(2f);
                    }
                }
                maxGrabCapacity = false;
            }
        }
    }

    public void setMaxGrabCapacity(bool grabAvailable)
    {
        this.maxGrabCapacity = grabAvailable;
    }
}
