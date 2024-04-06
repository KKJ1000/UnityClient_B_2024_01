using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100; //�÷��̾� ü��

    //�÷��̾ ���ظ� ���� �� ȣ�� �Ǵ� �Լ�
    //�Լ��� ��ȯ�� ���ٸ� �Լ��� �տ� void�� �����ش�.
    //�Լ����� ���� �� �����ϴ� ���� ������ Ÿ���� �Լ� �տ� ��� ����� �Ѵ�.
    //�����ϴ� ���� ���� ��� void��� ��Ī���� �Լ��տ� �����ְ� �ش� �Լ��� ���ϰ��� ���ٴ� �� �����ϰ� �ȴ�. void = �� ����
    public void TakeDamage(int damage) 
    {
        //�÷��̾� ü�� ����
        health -= damage; // ���� ������ �÷��̾� ü�� �Լ��� helth - damage �� �ٽ� helth�� ������ ���� ���� ������ ����ŭ ü���� ���̰� �ȴ�.
        Debug.Log("�÷��̾ ü�� " + health); //����� �α׸� ����  �÷��̾��� ü���� ����غ���.
        //�÷��̾��� ü���� 0���Ϸ� ������ �� ��� ó��
        if(health <= 0) // �÷��̾��� ü���� 0���Ϸ� �Ǿ��� �� 
        {
            Die(); //��� �Լ��� ����.
        }
    }

    private void Die()
    {
        Debug.Log("�÷��̾ ����߽��ϴ�");
        //��� ó�� ���� �߰� 
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
