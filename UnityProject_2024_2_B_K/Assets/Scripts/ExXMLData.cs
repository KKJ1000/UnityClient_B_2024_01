using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class PlayerData
{
    public string playerName;
    public int playerLevel;
    public List<string> items = new List<string>();
}
public class ExXMLData : MonoBehaviour
{
    string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/PlayerData.xml";
        Debug.Log(filePath);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = "플레이어 1";
            playerData.playerLevel = 1;
            playerData.items.Add("돌 1");
            playerData.items.Add("바위 1");
            SaveData(playerData);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            PlayerData playerData = new PlayerData();

            playerData = LoadData();

            Debug.Log(playerData.playerName);
            Debug.Log(playerData.playerLevel);
            Debug.Log(playerData.items[0]);
            Debug.Log(playerData.items[1]);
        }
    }
    void SaveData(PlayerData data)
    {
        //Class(객체)를 XML로 바꾸어 저장하는 것을 XML Serializer이라 한다.
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        //typeof()는 컴파일 타임에 해당 타입을 반환 인자로 Type그 자체를 받아서 인자의 표시된 타입을 반환합니다.
        FileStream steam = new FileStream(filePath, FileMode.Create);
        serializer.Serialize(steam, data);
        steam.Close();
    }

    PlayerData LoadData()
    {
        if(File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer (typeof(PlayerData));
            FileStream steam = new FileStream (filePath, FileMode.Open);
            PlayerData data = (PlayerData)serializer.Deserialize(steam);
            steam.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

   
}
