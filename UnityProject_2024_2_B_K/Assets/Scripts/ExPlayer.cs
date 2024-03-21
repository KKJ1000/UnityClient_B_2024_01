using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100; //플레이어 체력

    //플레이어가 피해를 받을 때 호출 되는 함수
    public void TakeDamage(int damage)
    {
        //플레이어 체력 감소
        health -= damage;
        Debug.Log("플레이어가 체력 " + health);
        //플레이어의 체력이 0이하로 떨어질 때 사망 처럼
        if(health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("플레이어가 사망했습니다");
        //사망 처리 로직 추가
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
