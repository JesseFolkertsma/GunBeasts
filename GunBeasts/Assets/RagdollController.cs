using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour {

    public float speed;
    public Transform hips;
    public Rigidbody controller;
    public Animator anim;

    public HingeJoint z_LowerArmL;
    public HingeJoint z_LowerArmR;

    public HingeJoint z_handL;
    public HingeJoint z_handR;

    private JointLimits z_hl;
    private JointLimits z_hr;

    public ConfigurableJoint pivotJoint;
    public ConfigurableJoint capsuleController;

    public RotateBox rotateBox;

    private void Start()
    {
        z_hl = z_handL.limits;
        z_hr = z_handR.limits;

        z_handL.limits = z_hl;
        z_handR.limits = z_hr;
    }

    private void LateUpdate()
    {
        
    }
}
