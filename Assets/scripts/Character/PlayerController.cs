using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 2;
    [SerializeField] private int hightJump = 350;

    private PlayerVisual playerVisual;
    private Rigidbody2D rigidbody;
    private bool isJump = false;

    private enum State
    {
        Walk,
        JumpStart,
        JumpEnd
    }


    private void Start()
    {
        playerVisual = GetComponent<PlayerVisual>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        //Передвижение персонажа по горизонтали.
        if (Input.GetAxis("Horizontal") != 0)
        {
            float move = Input.GetAxis("Horizontal");
            transform.eulerAngles = move > 0 ? new Vector3(0, -180f, 0) : new Vector3(0, 0, 0);
            playerVisual.setStatus(true, (int)State.Walk);
            transform.position += new Vector3(move, 0, 0) * speed * Time.deltaTime;
        }
        else
        {
            playerVisual.setStatus(false, (int)State.Walk);
        }
    }

    private void OnMouseDown()
    {
        if (!isJump)
        {
            playerVisual.setTrigger((int)State.JumpStart);
            rigidbody.AddForce(Vector2.up * hightJump);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJump)
        {
            playerVisual.setTrigger((int)State.JumpEnd);
            isJump= false;
        }
    }
}
