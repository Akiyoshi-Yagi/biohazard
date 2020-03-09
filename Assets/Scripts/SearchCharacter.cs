using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private EnemyMove enemyMove;

    void Start()
    {
        enemyMove = GetComponentInParent<EnemyMove>();

    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            
            EnemyMove.EnemyState state = enemyMove.GetState();
            if(state != EnemyMove.EnemyState.Chase)
            {
                Debug.Log("プレイヤー発見！！！");
                enemyMove.SetState(EnemyMove.EnemyState.Chase, col.transform);
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("見失う");
            enemyMove.SetState(EnemyMove.EnemyState.Wait);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
