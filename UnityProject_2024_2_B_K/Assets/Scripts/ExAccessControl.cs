using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExAccessControl : MonoBehaviour
{
    //다른 스크립트에서 직접 접근 가능
    public int publicValue;

    //같은 클래스내에서만 접근 가능
    private int privateValue; //ex) ExAccessControl 클래스에서만 접근 가능.

    //같은 클래스 및 파생 클래스에서 접근 가능, 이 클래스를 상속 받아 새로 정의된 클래스를 파생 클래스라고 한다.
    // New Class : ExAccessControl 이렇게 되면 New Class가 파생 클래스가 되고 파생클래스에서 protectedValue로 접근 가능하다.
    protected int protectedValue;

    //같은 어셈블리(프로젝트 내 다른 스크립트) 내에서 접근 가능 
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

public class ChildClass : ParentClass //위에서 봤듯이 PartentClass 상속 받은 ChildClass가 protectedValueParent에 접근이 가능하다.
{
    void Start()
    {
        Debug.Log(protectedValueParent);
    }
}
