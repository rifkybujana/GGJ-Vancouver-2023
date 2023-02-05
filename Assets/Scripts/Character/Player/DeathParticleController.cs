using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticleController : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void OnParticleSystemStopped() 
    {
        player.BackToCheckpoint();
    }
}
