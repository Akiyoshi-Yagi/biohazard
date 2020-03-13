using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //Debug.Log("大当たり！！！");
            col.GetComponent<playerMove>().TakeDamage();

        }
    }
}
