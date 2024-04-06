using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text;
using System;
using System.Linq;

public class ExEncrypt : MonoBehaviour
{
    string filePath;
    string key = "ThisIsASecrtKey"; //암호화 키
    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/EncryptPlayerData.json";
        Debug.Log(filePath);
    }

    void SaveData(PlayerData data)
    {
        //JSON 직렬화
        string jsonData = JsonConvert.SerializeObject(data);

        //데이터를 바이드 배열로 변환
        byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(jsonData);

        //암호화
        byte[] encryptedBytes = Encrypt(bytesToEncrypt);

        //암호화된 데이터를 Base64문자열로 변환
        string encrytedData = Convert.ToBase64String(encryptedBytes);

        //파일 저장
        File.WriteAllText(filePath, jsonData);
    }

    PlayerData LoadData()
    {
        if (File.Exists(filePath))
        {
            //파일에서 암호화된 데이터 읽기
            string encryptedData = File.ReadAllText(filePath);

            //Base64 문자열을 바이드 배열로 변환
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

            //복호화
            byte[] decryptedBytes = Decrypt(encryptedBytes);

            //바이트 배열을 문자열로 변환
            string jsonData = Encoding.UTF8.GetString(decryptedBytes);

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
            for (int i = 0; i < playerData.items.Count; i++)
            {
                Debug.Log(playerData.items[i]);
            }

        }
    }

    byte[] Encrypt(byte[] plainBytes)
    {
        using(Aes aesAlg = Aes.Create()) 
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = new byte[16];

            //암호화 변환기 생성
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            //스트림 생성
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                //스트림에 암호화 변환기를 연결하여 암호화 스트림을 생성
                using(CryptoStream csEncrpt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    //암호화 스트림에 데이터 쓰기
                    csEncrpt.Write(plainBytes, 0, plainBytes.Length);
                    csEncrpt.FlushFinalBlock();

                    //암호화된 데이터 바이트를 배열로 ㅕㄴ환
                    return msEncrypt.ToArray();
                }
            }
        }
    }

    byte[] Decrypt(byte[] encryptedBytes)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = new byte[16];

            //암호화 변환기 생성
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            //스트림 생성
            using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
            {
                //스트림에 암호화 변환기를 연결하여 암호화 스트림을 생성
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[encryptedBytes.Length];

                    int decryptedByteCount = csDecrypt.Read(decryptedBytes, 0, decryptedBytes.Length);

                    return decryptedBytes.Take(decryptedByteCount).ToArray();
                }
            }
        }
    }
}
