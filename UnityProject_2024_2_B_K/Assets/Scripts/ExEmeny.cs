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
            Debug.Log("Ÿ���÷��̾� ����");
            if(targetPlayer != null)
            {
                AttackPlayer(targetPlayer);
            }
        }
    }
}
