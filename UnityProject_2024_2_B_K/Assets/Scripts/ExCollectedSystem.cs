using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExItem
{
    public bool IsCollected; //ȹ�濩��
}
public class ExCollectedSystem : MonoBehaviour
{
    public List<ExItem> collectedItem = new List<ExItem>();
    // Start is called before the first frame update
    void Start()
    {
        collectedItem.Add(new ExItem()); //�÷��� �� ����Ʈ
        collectedItem.Add(new ExItem());
        collectedItem[0].IsCollected = true;
        collectedItem[1].IsCollected = false;//��� �������� Ʈ�簡 �Ǹ� �ؿ� ��� ������ ���� �˻翡�� ��� ��Ҵٰ� ���.
        CheckAllItemsCollected();

    }

    void CheckAllItemsCollected()
    {
        if (collectedItem.All(item => item.IsCollected)) //��� �������� ���� �Ǿ����� �˻�
        {
            Debug.Log("All Items Collected");
        }
        else
        {
            Debug.Log("Not all items collected!");
        }
    }

    
}
