using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100; //플레이어 체력

    //플레이어가 피해를 받을 때 호출 되는 함수
    //함수의 반환이 없다면 함수명 앞에 void를 붙혀준다.
    //함수명을 지을 때 리턴하는 값의 데이터 타입을 함수 앞에 명시 해줘야 한다.
    //리턴하는 값이 없을 경우 void라는 명칭으로 함수앞에 적어주고 해당 함수는 리턴값이 없다는 걸 내포하게 된다. void = 빈 공간
    public void TakeDamage(int damage) 
    {
        //플레이어 체력 감소
        health -= damage; // 위에 선언한 플레이어 체력 함수를 helth - damage 를 다시 helth에 대입해 실제 입은 데미지 수만큼 체력이 깍이게 된다.
        Debug.Log("플레이어가 체력 " + health); //디버그 로그를 통해  플레이어의 체력을 출력해본다.
        //플레이어의 체력이 0이하로 떨어질 때 사망 처럼
        if(health <= 0) // 플레이어의 체력이 0이하로 되었을 때 
        {
            Die(); //사망 함수를 실행.
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
