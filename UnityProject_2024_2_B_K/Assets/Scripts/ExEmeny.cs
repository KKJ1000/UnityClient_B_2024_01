using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEmeny : MonoBehaviour
{
    public ExPlayer targetPlayer; 
    //C# ������ Ŭ������ ��ü(�ν��Ͻ�)�� ���� ����Ѵ�. �̰��� ��ü �ʱ�ȭ��� �Ѵ�.
    //��ü�� �ʱ�ȭ �Ҷ��� ExPlayer player = new ExPlayer();
    //�ʱ�ȭ�� �ϸ鼭 Ŭ���� �ȿ� ������ ���� �ְ� �ʹٸ�
    //�����ڸ� ����ϸ� �ξ� �� ���������� Ŭ������ �ʱ�ȭ �� �� �ִ�.
    //Ŭ������ ���� �� �� Ŭ������ ���� ������ �Լ��� ���� ���ָ� �װ��� �����ڰ� �˴ϴ�. �̶� ��ȯ ���� ����.
    // ExPlayer Ŭ���� �ȿ� �Լ��� ExPlayer(); �Լ��� �����ϰ� �� �ȿ� ExPlayer(int first, int second);��
    //�ؼ� �ʱ�ȭ �ҋ� Explayer player = ExPlayer(1,2); �̷������� �����ϴ�.
    
    private int damage = 20; //�� ���ݷ�;

    public void AttackPlayer(ExPlayer player) //�÷��̾� ���� �Լ�.
    {
        player.TakeDamage(damage);
    }

  
    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))//�����̽� ��ư�� ������ �� 
        {
            Debug.Log("Ÿ���÷��̾� ����"); //Ÿ���÷��̾� �����̶�� �޼����� ���.
            if(targetPlayer != null) //Ÿ�� �÷��̾� ������ ���� ���� �� 
            {
                AttackPlayer(targetPlayer); //�÷��̾� ���� �Լ��� �����ϰ� �� �Լ��ȿ� Ÿ���÷��̾ �ִ´�.
            }
        }
    }
}
