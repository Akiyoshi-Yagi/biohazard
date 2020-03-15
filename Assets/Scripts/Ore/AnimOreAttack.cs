using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOreAttack : MonoBehaviour
{
    private playerMove playerMove;
    [SerializeField] CapsuleCollider capsuleCollider;

    void Start()
    {
        playerMove = GetComponent<playerMove>();

    }


    public void NewEvent()
    {
        return;
    }

    public void AttackStart()
    {
        //Debug.Log("当たり判定");
        capsuleCollider.enabled = true;
    }

    public void AttackEnd()
    {
        capsuleCollider.enabled = false;
    }

    public void StateEnd()
    {
        playerMove.SetState(playerMove.OreState.Normal);
    }

    //public void EndDamage()
    //{
    //    characterScript.SetState(CharacterScript.MyState.Normal);
    //}
}
