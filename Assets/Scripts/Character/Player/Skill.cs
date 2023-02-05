using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private Levels levels;
    [SerializeField] private ColorListHolder skillUI;
    
    [SerializeField] private KeyCode skillInput = KeyCode.LeftShift;

    [SerializeField] private float skillCooldown = 10;
    [SerializeField] private float skillDuration = 1;

    private float cooldownTimer, durationTimer;

    [HideInInspector] public List<colors> colorUnlocked = new List<colors>();

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
            {
                SelectColor(0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (colorUnlocked.Count >= 2)
            {
                SelectColor(1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (colorUnlocked.Count >= 3)
            {
                SelectColor(2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (colorUnlocked.Count >= 4)
            {
                SelectColor(3);
            }
        }

        skillUI.cooldownSlider.value = 1 - cooldownTimer / skillCooldown;

        if (skillUI.activated && skillUI.cooldownSlider.value < 1)
        {
            skillUI.cooldownSlider.gameObject.SetActive(true);
        }
        else
        {
            skillUI.cooldownSlider.gameObject.SetActive(false);
        }
    }

    private void SelectColor(int i)
    {
        for (int j = 0; j < colorUnlocked.Count; j++)
        {
            if (j == i)
            {
                skillUI.colorList[i].color = new Color(
                    skillUI.colorList[i].color.r,
                    skillUI.colorList[i].color.g,
                    skillUI.colorList[i].color.b,
                    1
                );

                continue;
            }

            skillUI.colorList[j].color = new Color(
                skillUI.colorList[j].color.r,
                skillUI.colorList[j].color.g,
                skillUI.colorList[j].color.b,
                0
            );
        }
        colorSelected = colorUnlocked[i];
    }

    public void ResetCooldown()
    {
        cooldownTimer = 0;
    }

    public void AddColor(colors col)
    {
        if (colorUnlocked.Count <= 0)
            skillUI.Activated();

        colorSelected = col;
        colorUnlocked.Add(col);

        for (int i = 0; i < colorUnlocked.Count; i++)
        {
            skillUI.colorList[i].gameObject.SetActive(true);
        }

        SelectColor(colorUnlocked.Count - 1);
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
