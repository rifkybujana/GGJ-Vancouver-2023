using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : MonoBehaviour
{
    private Animator UIAnimator;

    private void Start()
    {
        UIAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (UIAnimator.enabled && Input.GetKeyDown(KeyCode.Space))
        {
            UIAnimator.SetTrigger("Close");
        }
    }

    public void DisableAnimation()
    {
        GetComponent<Animator>().enabled = false;
    }
}
