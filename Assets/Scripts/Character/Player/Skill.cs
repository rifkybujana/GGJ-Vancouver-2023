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

    private colors colorSelected = colors.None;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(skillInput) && cooldownTimer <= 0 && colorSelected != colors.None)
        {
            cooldownTimer = skillCooldown;
            durationTimer = skillDuration;

            StartCoroutine("SetBlocksActivation", true);
        }

        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        if (durationTimer > 0)
        {
            durationTimer -= Time.deltaTime;

            if (durationTimer <= 0)
                StartCoroutine("SetBlocksActivation", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (colorUnlocked.Count >= 1)
                colorSelected = colorUnlocked[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (colorUnlocked.Count >= 2)
                colorSelected = colorUnlocked[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (colorUnlocked.Count >= 3)
                colorSelected = colorUnlocked[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (colorUnlocked.Count >= 4)
                colorSelected = colorUnlocked[3];
        }
    }

    public void AddColor(colors col)
    {
        colorSelected = col;
        colorUnlocked.Add(col);
    }

    private IEnumerator SetBlocksActivation(bool val)
    {
        foreach (Block block in levels.CurrentLevel.blocks)
        {
            if (block.colorCategory != colorSelected)
                continue;

            block.setActivation(val);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
