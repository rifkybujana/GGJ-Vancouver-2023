using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHint : MonoBehaviour
{
    
    [SerializeField] private Skill playerSkill;

    private SpriteRenderer sprite;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    private void Update() {
        if (playerSkill.colorUnlocked.Count > 0)
            sprite.enabled = true;
    }

}
