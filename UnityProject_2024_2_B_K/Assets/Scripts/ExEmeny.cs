using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEmeny : MonoBehaviour
{
    public ExPlayer targetPlayer;
    private int damage = 20;

    public void AttackPlayer(ExPlayer player)
    {
        player.TakeDamage(damage);
    }

  
    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("타겟플레이어 공격");
            if(targetPlayer != null)
            {
                AttackPlayer(targetPlayer);
            }
        }
    }
}
