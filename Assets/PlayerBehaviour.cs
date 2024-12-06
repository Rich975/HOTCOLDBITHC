using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour

{
    [SerializeField] private float playerSpeed = 10f;
    private float hMovement;
    private float vMovement;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        PlayerMovement();
        //PlayerMovementAnimations();
        //PlayerAttack();
    }

    private void PlayerMovement()
    {
        hMovement = Input.GetAxisRaw("Horizontal");
        vMovement = Input.GetAxisRaw("Vertical");

        if (rb != null)
        {
            Vector3 movement = new Vector3(hMovement, 0, vMovement).normalized * playerSpeed;
            rb.AddForce(movement);
        }
    }

    private void PlayerMovementAnimations()
    {
        // Check the magnitude of the velocity vector
        if (rb.velocity.magnitude > 0.1f) // Adjust the threshold as needed
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Punch");
        }
    }
}

