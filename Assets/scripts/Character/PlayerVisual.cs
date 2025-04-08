using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private Animator animator;
    private readonly string[] statusNames = { "isWalk", "onJumpStart", "onJumpEnd" };


    private void Awake()
    {
        animator = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        //animator.SetBool(statusNames[state], knightStatus);
    }

    public void setStatus(bool knightStatus, int state)
    {
        animator.SetBool(statusNames[state], knightStatus);
    }

    public void setTrigger(int state)
    {
        animator.SetTrigger(statusNames[state]);
    }

    public void PlayParticle()
    {
        particleSystem.Play();
    }
}
