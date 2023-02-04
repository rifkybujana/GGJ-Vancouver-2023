using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public List<Block> blocks;

    private void Start() 
    {
        blocks = new List<Block>(gameObject.GetComponentsInChildren<Block>());
    }

    public Block this[int index]
    {
        get { return blocks[index]; }
    }
}
