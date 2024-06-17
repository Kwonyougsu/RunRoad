using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 curMovement;
    private Rigidbody rb;
    public GameObject EndPanel;
    private Animator animator;
    Coroutine DieMotion;

    public float speed;
    private bool Stay;

    private void Awake()
    {
        speed = 2.5f;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        Stay = true;
        animator.SetBool("Stay", Stay);
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        Vector3 horizontalMovement = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        float currentSpeed = horizontalMovement.magnitude;
        animator.SetFloat("Speed", currentSpeed);
    }

    private void FixedUpdate()
    {
        if (Stay == true)
        {
            Move();
        }
    }

    #region player Move
    public void Onmove(InputAction.CallbackContext context)
    {
        
        if (context.phase == InputActionPhase.Performed)
        {
            curMovement = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovement = Vector2.zero;
        }
    }
    private void Move()
    {
        Vector3 dir = transform.forward * curMovement.y + transform.right * curMovement.x;
        dir *= speed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object") 
        {
            DieMotion = StartCoroutine(DieAnimation());
        }
    }

    IEnumerator DieAnimation()
    {
        Stay = false;
        animator.SetBool("Stay", Stay);
        EndPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        yield return null;
    }

}
