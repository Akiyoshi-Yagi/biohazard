using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimAttackEnemy : MonoBehaviour
{

    private EnemyMove enemyMove;
    [SerializeField] private SphereCollider sphereCollider;

    void Start()
    {
        enemyMove = GetComponent<EnemyMove>();

        
    }

    public void NewEvent()
    {
        return;
    }

    public void AttackStart()
    {
        //Debug.Log("ON");
        sphereCollider.enabled = true;
    }

    public void AttackEnd()
    {
        sphereCollider.enabled = false;

    }
    public void StateEnd()
    {
        enemyMove.SetState(EnemyMove.EnemyState.Freeze);
    }
    public void EndDamage()
    {
        enemyMove.SetState(EnemyMove.EnemyState.Walk);
    }
}
