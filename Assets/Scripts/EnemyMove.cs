using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private CharacterController enemyContoroller;
    private Animator animator;

    private Vector3 destination;
    [SerializeField] private float walkSpeed = 1.0f;
    private Vector3 velocity;
    private Vector3 direction;

    //ゾンビが目的地についたかどうかを判定
    private bool arrived;


    void Start()
    {
        arrived = false;
        enemyContoroller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        destination = new Vector3(15f, 0f, 15f);
        velocity = Vector3.zero;
    }

    void Update()
    {
        if (enemyContoroller.isGrounded && (!arrived))
        {
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 2.0f);
            direction = (destination - transform.position).normalized;
            transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
            velocity = direction * walkSpeed;
            Debug.Log(transform.position);
             
        }
        if(Vector3.Distance(transform.position, destination) < 2.0f)
        {
            arrived = true;
            animator.SetFloat("Speed", 0f);
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyContoroller.Move(velocity * Time.deltaTime);
    }
}
