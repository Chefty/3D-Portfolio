using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PnjAnimationEnum
{
    BreakDance,
    TwistDance,
    YMCADance,
    SillyDance,
};

public class PNJAnimationSelector : MonoBehaviour
{
    public PnjAnimationEnum pnjAnimation = PnjAnimationEnum.BreakDance;

    // Start is called before the first frame update
    void Start()
    {
        var animator = GetComponent<Animator>();
        if (animator)
            animator.SetInteger("PNJAnimation", (int)pnjAnimation);
    }
}
