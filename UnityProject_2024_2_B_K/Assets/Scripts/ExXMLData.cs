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
            playerData.playerName = "�÷��̾� 1";
            playerData.playerLevel = 1;
            playerData.items.Add("�� 1");
            playerData.items.Add("���� 1");
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
        //Class(��ü)�� XML�� �ٲپ� �����ϴ� ���� XML Serializer�̶� �Ѵ�.
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        //typeof()�� ������ Ÿ�ӿ� �ش� Ÿ���� ��ȯ ���ڷ� Type�� ��ü�� �޾Ƽ� ������ ǥ�õ� Ÿ���� ��ȯ�մϴ�.
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
