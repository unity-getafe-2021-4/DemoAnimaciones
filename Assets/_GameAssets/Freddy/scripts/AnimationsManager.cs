using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    Animator animator;
    public float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetTrigger("Punch");
        }
        AnimatorClipInfo[] infoAnimations = animator.GetCurrentAnimatorClipInfo(0);
        if (infoAnimations[0].clip.name == "Zombie Running")
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
