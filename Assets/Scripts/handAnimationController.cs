using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class handAnimationController : MonoBehaviour
{
    public InputActionProperty pinchAnimation;
    public InputActionProperty fistAnimation;
    public Animator handAnimation;

    void Update()
    {
        float pinchValue = pinchAnimation.action.ReadValue<float>();
        Debug.Log("pinch value:" + pinchValue);
        handAnimation.SetFloat("pinch", pinchValue);

        float fistValue = fistAnimation.action.ReadValue<float>();
        Debug.Log("fist value:" + fistValue);
        handAnimation.SetFloat("fist", fistValue);
    }
}
