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

    private List<colors> colorUnlocked = new List<colors>();

    private colors colorSelected = colors.White;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(skillInput) && cooldownTimer <= 0 && colorSelected != colors.None)
        {
            cooldownTimer = skillCooldown;
            durationTimer = skillDuration;

            foreach (Block block in levels.CurrentLevel.blocks)
            {
                if (block.colorCategory != colorSelected)
                    continue;

                block.setActivation(true);
            }
        }

        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        if (durationTimer > 0)
        {
            durationTimer -= Time.deltaTime;

            if (durationTimer <= 0)
            {
                foreach (Block block in levels.CurrentLevel.blocks)
                {
                    if (block.colorCategory != colorSelected)
                        continue;
                        
                    block.setActivation(false);
                }
            }
        }
    }
}
