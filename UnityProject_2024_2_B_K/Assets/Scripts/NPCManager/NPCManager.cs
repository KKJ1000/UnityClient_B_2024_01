using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public Entity_DialogData entity_Dialog;


    public Entity_DialogData.Param GetParamData(int npc, int gamestate)    //npc ��ȣ�� ���� ���� ������ ���̾�α� Ŭ������ �޾ƿ�.
    {
        foreach(Entity_DialogData.Param param in entity_Dialog.sheets[0].list)
        {
            if(param.npc  == npc && param.gamestate == gamestate)
            {
                return param;
            }
        }

        //�ش� �����Ͱ� ���� ��� null ��ȯ
        return null;
    }
}
