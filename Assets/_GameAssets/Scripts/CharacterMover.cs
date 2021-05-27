using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private const string PARAM_DELTA = "Delta";
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
        z = Input.GetAxis("Vertical");
        if (z>0){
            delta+=speed*Time.deltaTime;
        } else {
            delta-=speed*Time.deltaTime;
        }
        delta=Mathf.Clamp(delta,0,1);
        animator.SetFloat(PARAM_DELTA, delta);
        transform.Translate(Vector3.forward * delta * Time.deltaTime * walkSpeed);
    }
}
