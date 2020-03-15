using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            Debug.Log("的に命中");
            col.GetComponent<EnemyMove>().SetState(EnemyMove.EnemyState.Damage);
        }
    }
}
