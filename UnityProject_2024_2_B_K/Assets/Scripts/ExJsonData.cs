using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json; //JSON 직렬화를 위한 패키지
using UnityEngine;
using System.IO;

public class ExJsonData : MonoBehaviour
{
    string filePath;
    
    void Start()
    {
        filePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(filePath);
    }

    void SaveData(PlayerData data)
    {
        //JSON 직렬화
        string jsonData = JsonConvert.SerializeObject(data);
        //파일 저장
        File.WriteAllText(filePath, jsonData);
    }

    PlayerData LoadData()
    {
        if (File.Exists(filePath))
        {
            //파일에서 데이터 읽기
            string jsonData = File.ReadAllText(filePath);

            //JSON역직렬화
            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(jsonData);
            return data;
        }
        else
        {
            return null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = "플레이어 1";
            playerData.playerLevel = 1;
            playerData.items.Add("돌 1");
            playerData.items.Add("바위 1");
            SaveData(playerData);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerData playerData = new PlayerData();

            playerData = LoadData();

            Debug.Log(playerData.playerName);
            Debug.Log(playerData.playerLevel);
            for(int i = 0; i<playerData.items.Count;i++)
            {
                Debug.Log(playerData.items[i]);
            }
            
        }
    }
}
