using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExAccessControl : MonoBehaviour
{
    //�ٸ� ��ũ��Ʈ���� ���� ���� ����
    public int publicValue;

    //���� Ŭ������������ ���� ����
    private int privateValue; //ex) ExAccessControl Ŭ���������� ���� ����.

    //���� Ŭ���� �� �Ļ� Ŭ�������� ���� ����, �� Ŭ������ ��� �޾� ���� ���ǵ� Ŭ������ �Ļ� Ŭ������� �Ѵ�.
    // New Class : ExAccessControl �̷��� �Ǹ� New Class�� �Ļ� Ŭ������ �ǰ� �Ļ�Ŭ�������� protectedValue�� ���� �����ϴ�.
    protected int protectedValue;

    //���� �����(������Ʈ �� �ٸ� ��ũ��Ʈ) ������ ���� ���� 
    internal int internalValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class ParentClass
{
    protected int protectedValueParent;
}

public class ChildClass : ParentClass //������ �õ��� PartentClass ��� ���� ChildClass�� protectedValueParent�� ������ �����ϴ�.
{
    void Start()
    {
        Debug.Log(protectedValueParent);
    }
}
