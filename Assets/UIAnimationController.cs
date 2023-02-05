using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : MonoBehaviour
{
    private Animator UIAnimator;

    [SerializeField] private Skill skill;

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
        if (skill.colorUnlocked.Contains(colors.Finish))
        {
            UIAnimator.SetTrigger("Final");
            return;
        }
        
        UIAnimator.Play("Picture");
        UIAnimator.enabled = false;
    }

    public void Finished()
    {
    }
}
