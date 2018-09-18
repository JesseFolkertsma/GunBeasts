using UnityEngine;
using System.Collections;

public class HingeJointTarget : MonoBehaviour
{
    public enum Axis
    {
        X,Y,Z,
    };

    public HingeJoint hj;
    public Transform target;
    public Axis axis;
    public bool invert;

    void Update()
    {
        if (hj != null)
        {
            JointSpring js;
            switch (axis) {
                case Axis.X:
                    js = hj.spring;

                    js.targetPosition = target.transform.localEulerAngles.x;
                    if (js.targetPosition > 180)
                        js.targetPosition = js.targetPosition - 360;
                    if (invert)
                        js.targetPosition = js.targetPosition * -1;

                    js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

                    hj.spring = js;
                break;

                case Axis.Y:
                    js = hj.spring;
                    js.targetPosition = target.transform.localEulerAngles.y;
                    if (js.targetPosition > 180)
                        js.targetPosition = js.targetPosition - 360;
                    if (invert)
                        js.targetPosition = js.targetPosition * -1;

                    js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

                    hj.spring = js;
                break;

                case Axis.Z:
                    js = hj.spring;
                    js.targetPosition = target.transform.localEulerAngles.z;
                    if (js.targetPosition > 180)
                        js.targetPosition = js.targetPosition - 360;
                    if (invert)
                        js.targetPosition = js.targetPosition * -1;

                    js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

                    hj.spring = js;
                break;
            }
        }
    }
}