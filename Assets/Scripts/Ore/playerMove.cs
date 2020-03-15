using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float walkSpeed;

    public enum OreState
    {
        Normal,
        Damaged,
        Attack,
    };

    //コンポーネントもフィールドに入れられる
    private OreState state;
    private CharacterController characterController;
    private Vector3 velocity;
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //transform.position = new Vector3(0f, 1f, 0f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == OreState.Normal)
        {
            //　地面に接地してる時は速度を初期化
            if (characterController.isGrounded)
            {
                velocity = Vector3.zero;

                //Debug.Log("動くやで");
                var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

                if (input.magnitude > 0f)
                {
                    animator.SetFloat("Speed", input.magnitude);
                    transform.LookAt(transform.position + input);
                    velocity += input.normalized * walkSpeed;
                }
                else
                {
                    animator.SetFloat("Speed", 0f);
                }
                if (Input.GetKeyDown("space"))
                {
                    SetState(OreState.Attack);
                }
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }

    public void TakeDamage ()
    {
        //Debug.Log("anim");
        state = OreState.Damaged;
        velocity = Vector3.zero;
        animator.SetTrigger("Damage");
        
        //characterController.Move(enemyTransform.forward * 0.5f);

    }

    public void SetState(OreState tempState)
    {
        if (tempState == OreState.Normal)
        {
            //Debug.Log("Normal化");
            state = tempState;
        }
        else if (tempState == OreState.Attack)
        {
            state = tempState;
            velocity = Vector3.zero;
            animator.SetTrigger("Attack");
        }
    }
}
