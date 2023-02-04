using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public int currentLevel = 0;

    public List<GameObject> levelManagers = new List<GameObject>();

    private void Start() 
    {
        for (int i = 0; i < levelManagers.Count; i++)
        {
            if (i == currentLevel)
                continue;

            levelManagers[i].SetActive(false);
        }
    }

    public LevelManager this[int index]
    {
        get { return levelManagers[index].GetComponent<LevelManager>(); }
    }
    
    public GameObject ChangeLevel(int level)
    {
        levelManagers[currentLevel].SetActive(false);
        levelManagers[level].SetActive(true);

        currentLevel = level;
        return levelManagers[level];
    }
}
