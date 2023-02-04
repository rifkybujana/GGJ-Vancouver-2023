using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();

    public Block this[int index]
    {
        get { return blocks[index].GetComponent<Block>(); }
    }
}
