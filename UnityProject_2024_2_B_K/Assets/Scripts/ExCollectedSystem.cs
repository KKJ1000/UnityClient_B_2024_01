using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExItem
{
    public bool IsCollected; //획득여부
}
public class ExCollectedSystem : MonoBehaviour
{
    public List<ExItem> collectedItem = new List<ExItem>();
    // Start is called before the first frame update
    void Start()
    {
        collectedItem.Add(new ExItem()); //컬랙팅 할 리스트
        collectedItem.Add(new ExItem());
        collectedItem[0].IsCollected = true;
        collectedItem[1].IsCollected = false;//모든 아이템이 트루가 되면 밑에 모든 아이템 수집 검사에서 모두 모았다고 뜬다.
        CheckAllItemsCollected();

    }

    void CheckAllItemsCollected()
    {
        if (collectedItem.All(item => item.IsCollected)) //모든 아이템이 수집 되었는지 검사
        {
            Debug.Log("All Items Collected");
        }
        else
        {
            Debug.Log("Not all items collected!");
        }
    }

    
}
