using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private const string PARAM_DELTA = "Delta";
    private const string PARAM_JUMP = "Jump";
    [SerializeField] float walkSpeed;
    [SerializeField] float speed;
    [SerializeField] float delta = 0;
    [SerializeField] float z;
    Animator animator;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        CalculateDelta();
        SetDeltaToAnimator();
        MoveCharacter();
        TryJump();
    }

    private void SetDeltaToAnimator()
    {
        animator.SetFloat(PARAM_DELTA, delta);
    }

    private void MoveCharacter()
    {
        transform.Translate(Vector3.forward * delta * Time.deltaTime * walkSpeed);
    }

    private void CalculateDelta()
    {
        z = Input.GetAxis("Vertical");
        if (z > 0)
        {
            delta += speed * Time.deltaTime;
        }
        else
        {
            delta -= speed * Time.deltaTime;
        }
        delta = Mathf.Clamp(delta, 0, 1);
    }

    private void TryJump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) && delta == 1)
        {
            animator.SetTrigger(PARAM_JUMP);
        }
    }
}
