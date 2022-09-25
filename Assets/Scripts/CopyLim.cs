using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyLim : MonoBehaviour
{
    [SerializeField] private Transform targetLimb;

    [SerializeField] private ConfigurableJoint configurableJoint;

    Quaternion targetInitialRotation;
    void Start()
    {
        this.configurableJoint = this.GetComponent<ConfigurableJoint>();
        this.targetInitialRotation = this.targetLimb.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.configurableJoint.targetRotation = copyRotation();
    }

    private Quaternion copyRotation()
    {
        return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
    }
}
