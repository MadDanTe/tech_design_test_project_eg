using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem particleSystem;
    private const string ON_CLICK = "onClick";

    private void Start()
    {
        animator = GetComponent<Animator>();   
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnMouseDown()
    {
        animator.SetTrigger(ON_CLICK);
        particleSystem.Play();

    }
}
