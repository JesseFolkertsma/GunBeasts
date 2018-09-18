using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IkTest : MonoBehaviour {
    public bool arms;
    public Transform trans;
    public float legLenght;
    public float legspread = .5f;
    public float footNormalOffset = .2f;
    public float legspeed = .2f;
    public LayerMask mask;
    Animator anim;
    float footWeight = 0;
    Vector3 prevRight;
    Vector3 prevLeft;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (arms)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKPosition(AvatarIKGoal.RightHand, trans.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, trans.rotation);
            anim.SetLookAtWeight(1, .2f, 1, 0, .5f);
            anim.SetLookAtPosition(trans.position + trans.forward * 100);
        }
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, legLenght, mask))
        {
            footWeight = Mathf.Lerp(footWeight, 1, Time.deltaTime * legspeed);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, footWeight);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, footWeight);
            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, footWeight);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, footWeight);
            prevRight = (hit.point + hit.normal * footNormalOffset) + transform.right * (legspread / 2);
            anim.SetIKPosition(AvatarIKGoal.RightFoot, prevRight);
            prevLeft = (hit.point + hit.normal * footNormalOffset) - transform.right * (legspread / 2);
            anim.SetIKPosition(AvatarIKGoal.LeftFoot, prevLeft);
            anim.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.forward));
            anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward));
        }
        else
        {
            footWeight = Mathf.Lerp(footWeight, 0, Time.deltaTime * legspeed);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, footWeight);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, footWeight);
            anim.SetIKPosition(AvatarIKGoal.RightFoot, prevRight);
            anim.SetIKPosition(AvatarIKGoal.LeftFoot, prevLeft);
        }
    }
}
