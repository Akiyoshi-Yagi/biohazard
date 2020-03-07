using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float walkSpeed;

    //コンポーネントもフィールドに入れられる
    private CharacterController characterController;
    private Vector3 velocity;
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        transform.position = new Vector3(0f, 1f, 0f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            //magnitudeはベクトルの大きさ
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            if(velocity.magnitude > 0.1f)
            {
                animator.SetFloat("Speed", velocity.magnitude);
                //キャラクターの向きも押した方にする！
                transform.LookAt(transform.position + velocity);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * walkSpeed * Time.deltaTime);

    }
}
