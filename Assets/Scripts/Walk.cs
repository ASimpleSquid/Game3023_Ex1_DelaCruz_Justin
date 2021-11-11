using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    // This is to ensure the speed is set at a stable 1. This can be modified in Unity
    public float WalkSpeed;
    public float JumpForce;
    float Speed = 5;
    float horizontalMove = 0f;

    public Animator animator;

    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        WalkSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    { 
        horizontalMove = Input.GetAxisRaw("Horizontal") * WalkSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime* Speed;


        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement< 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

        if (Input.GetButtonDown("Jump") && _rigidbody.velocity.y == 0)
        {
            _rigidbody.AddForce(Vector2.up * 50);
        }



        if (_rigidbody.velocity.y == 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }

        if (_rigidbody.velocity.y > 0)
        {
            animator.SetBool("IsJumping", true);
        }

        if (_rigidbody.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
    }
}
