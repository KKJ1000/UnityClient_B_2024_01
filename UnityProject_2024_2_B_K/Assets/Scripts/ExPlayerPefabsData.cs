using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayerPefabsData : MonoBehaviour
{
    public int scorePoint;
    
    void SaveData(int score)
    {
        PlayerPrefs.SetInt("Score", score);  
        PlayerPrefs.Save(); //메모리 상에 저장된 데이터를 하드 드라이브에 저장한다.
        //PlayerPrefs는 유니티에서 제공해주는 데이터 관리 클래스이다.
        //이 클래스는 int, float, string, bool 타입의 변수를 저장하고 로드하는 기능을 제공한다.
    }

    int LoadData()
    {
        return PlayerPrefs.GetInt("Score");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveData(scorePoint);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Score: " + LoadData());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("Score");
        }
    }
}
