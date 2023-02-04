using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] private Levels levels;
    
    [SerializeField] private KeyCode skillInput = KeyCode.LeftShift;

    [SerializeField] private float skillCooldown = 10;
    [SerializeField] private float skillDuration = 1;

    private float cooldownTimer, durationTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(skillInput) && cooldownTimer <= 0)
        {
            cooldownTimer = skillCooldown;
            durationTimer = skillDuration;
            
            Debug.Log("Activate Skill!");
        }
        else if (Input.GetKeyDown(skillInput))
        {
            Debug.Log("Skill Cooldown!");
        }

        if (cooldownTimer >= 0)
            cooldownTimer -= Time.deltaTime;

        if (durationTimer >= 0)
            durationTimer -= Time.deltaTime;
    }
}
