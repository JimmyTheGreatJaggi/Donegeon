using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterStepOver : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public GameObject StepRayUpperGameObject;
    public GameObject StepRayLowerGameObject;
    public LayerMask GroundLayerMask;

    [SerializeField] private float stepHeight = 0.3f;
    [SerializeField] private float stepSmooth = 0.1f;

    void Awaken()
    {
        //StepRayUpperGameObject.transform.position = new Vector3(StepRayUpperGameObject.transform.position.x, stepHeight, StepRayUpperGameObject.transform.position.z);
    }

    void FixedUpdate()
    {
        StepClimb();

    }

    void StepClimb()
    {
        RaycastHit hitLowerHit;
        if (Physics.Raycast(StepRayLowerGameObject.transform.position, transform.TransformDirection(Vector3.forward), out hitLowerHit, 0.5f, GroundLayerMask))
        {
            RaycastHit hitUpperHit;
            if (!Physics.Raycast(StepRayUpperGameObject.transform.position, transform.TransformDirection(Vector3.forward),out hitUpperHit,1.7f, GroundLayerMask))
            {
                Rigidbody.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }
    }
}
