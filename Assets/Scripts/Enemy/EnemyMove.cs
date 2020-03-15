using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;
    private setPosition setPosition;

    
    [SerializeField] private float walkSpeed = 1.0f;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private float freezeTime = 0.5f;

    private Vector3 destination;
    private Vector3 velocity;
    private Vector3 direction;
    private float elapsedTime;
    private EnemyState state;
    private Transform playerTransform;


    //ゾンビが目的地についたかどうかを判定
    private bool arrived;

    public enum EnemyState
    {
        Walk,
        Wait,
        Chase,
        Attack,
        Freeze,
        Damage,
    };




    void Start()
    {
        elapsedTime = 0f;
        arrived = false;
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<setPosition>();
        destination = new Vector3(15f, 5f, 15f);
        velocity = Vector3.zero;
        SetState(EnemyState.Walk);
    }

    void Update()
    {
        //　見回りまたはキャラクターを追いかける状態


        Debug.Log(state);

        if (state == EnemyState.Walk || state == EnemyState.Chase)
        {
            //　キャラクターを追いかける状態であればキャラクターの目的地を再設定
            //Walk状態なら目的地はそのまま
            if (state == EnemyState.Chase)
            {
                setPosition.SetDestination(playerTransform.position);
            }
            if (enemyController.isGrounded)
            {
                velocity = Vector3.zero;
                animator.SetFloat("Speed", 2.0f);
                direction = (setPosition.GetDestination() - transform.position).normalized;
                transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
                velocity = direction * walkSpeed;
            }

            if (state == EnemyState.Walk)
            {
                if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.5f)
                {
                    SetState(EnemyState.Wait);
                    animator.SetFloat("Speed", 0.0f);
                }
            }
            else if (state == EnemyState.Chase)
            {
                if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 1.0f)
                {
                    SetState(EnemyState.Attack);
                    //animator.SetFloat("Speed", 0.0f);
                }
            }
            //　目的地に到着したかどうかの判定
        }
        else if (state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;

            //　待ち時間を越えたら次の目的地を設定
            if (elapsedTime > waitTime)
            {
                SetState(EnemyState.Walk);
            }
        }

        //フリーズ明けはとりあえずwalkに遷移させとけばええやん！！！
        else if(state == EnemyState.Freeze)
        {
            Debug.Log("sss");
            elapsedTime += Time.deltaTime;
            if(elapsedTime > freezeTime)
            {
                Debug.Log("bbb");
                SetState(EnemyState.Walk);
            }
        }


        //ほんとはここの速度計算するところは積分したいけどここでは簡単に和を計算するだけにする
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);
    }
    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        if (tempState == EnemyState.Walk)
        {
            arrived = false;
            elapsedTime = 0f;
            state = tempState;
            setPosition.CreateRandomPosition();
        }
        else if (tempState == EnemyState.Chase)
        {
            state = tempState;
            arrived = false;
            playerTransform = targetObj;
        }
        else if (tempState == EnemyState.Wait)
        {
            elapsedTime = 0f;
            state = tempState;
            arrived = true;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
        }
        else if (tempState == EnemyState.Attack)
        {
            state = tempState;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", true);
        }
        else if (tempState == EnemyState.Freeze)
        {
            state = tempState;
            elapsedTime = 0f;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", false);

        }
        else if (tempState == EnemyState.Damage)
        {
            state = tempState;
            velocity = Vector3.zero;
            animator.ResetTrigger("Attack");
            //Debug.Log("EnemyDamaged");
            animator.SetTrigger("Damage");
        }

    }
    public EnemyState GetState()
    {
        return state;
    }
}
