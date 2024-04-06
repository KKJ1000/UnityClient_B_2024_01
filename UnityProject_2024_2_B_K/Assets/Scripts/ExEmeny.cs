using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEmeny : MonoBehaviour
{
    public ExPlayer targetPlayer; 
    //C# 언어에서는 클래스의 객체(인스턴스)를 만들어서 사용한다. 이것을 객체 초기화라고 한다.
    //객체를 초기화 할때는 ExPlayer player = new ExPlayer();
    //초기화를 하면서 클래스 안에 변수에 값을 넣고 싶다면
    //생성자를 사용하면 훨씬 더 직관적으로 클래스를 초기화 할 수 있다.
    //클래스를 선언 할 때 클래스와 같은 명으로 함수를 선언 해주면 그것이 생성자가 됩니다. 이때 반환 형은 없다.
    // ExPlayer 클래스 안에 함수에 ExPlayer(); 함수를 선언하고 그 안에 ExPlayer(int first, int second);로
    //해서 초기화 할떄 Explayer player = ExPlayer(1,2); 이런식으로 가능하다.
    
    private int damage = 20; //적 공격력;

    public void AttackPlayer(ExPlayer player) //플레이어 공격 함수.
    {
        player.TakeDamage(damage);
    }

  
    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))//스페이스 버튼을 눌렀을 때 
        {
            Debug.Log("타겟플레이어 공격"); //타겟플레이어 공격이라는 메세지를 출력.
            if(targetPlayer != null) //타겟 플레이어 변수에 값이 있을 때 
            {
                AttackPlayer(targetPlayer); //플레이어 공격 함수를 실행하고 그 함수안에 타겟플레이어를 넣는다.
            }
        }
    }
}
