using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [HideInInspector] public int currentLevel = 0;

    [HideInInspector] public List<LevelManager> levelManagers;

    private void Start() 
    {
        levelManagers = new List<LevelManager>(gameObject.GetComponentsInChildren<LevelManager>());

        for (int i = 0; i < levelManagers.Count; i++)
        {
            if (i == currentLevel)
                continue;

            levelManagers[i].gameObject.SetActive(false);
        }
    }

    public LevelManager this[int index]
    {
        get { return levelManagers[index]; }
    }
    
    public GameObject ChangeLevel(int level)
    {
        levelManagers[currentLevel].gameObject.SetActive(false);
        levelManagers[level].gameObject.SetActive(true);

        currentLevel = level;
        return levelManagers[level].gameObject;
    }
}
