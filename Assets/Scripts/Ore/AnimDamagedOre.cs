using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDamagedOre : MonoBehaviour
{
    private playerMove playerMove;

    private void Start()
    {
        playerMove = GetComponent<playerMove>();

    }

    public void NewEvent()
    {
        return;
    }

    public void EndDamage()

    {
        //Debug.Log("EndDamage");
        playerMove.SetState(playerMove.OreState.Normal);
    }

}

