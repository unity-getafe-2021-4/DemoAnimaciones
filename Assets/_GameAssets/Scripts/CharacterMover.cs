using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private const string PARAM_VERTICAL = "Vertical";
    private const string PARAM_RUN_MODE = "RunMode";

    private const string PARAM_JUMP = "Jump";
    private const string PARAM_DANCE = "Dance";

    [SerializeField] float speedWalk;
    [SerializeField] float speedRun;
    [SerializeField] float z;
    [SerializeField] float x;

    float speed;
    Animator animator;
    bool runMode = false;
    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        InvokeRepeating("DanceRule",5,5);
    }

    void DanceRule(){
        if (Random.Range(0,10)>8){
            animator.SetTrigger(PARAM_DANCE);
        }
    }

    void Update()
    {
        z = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift)){
            runMode=true;
            speed = speedRun;
        } else {
            runMode=false;
            speed = speedWalk;
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            animator.SetTrigger(PARAM_JUMP);
        }
        
        Avanzar();
    }
    void Avanzar(){
        animator.SetFloat(PARAM_VERTICAL,z);
        animator.SetBool(PARAM_RUN_MODE,runMode);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * z);
    }
}
