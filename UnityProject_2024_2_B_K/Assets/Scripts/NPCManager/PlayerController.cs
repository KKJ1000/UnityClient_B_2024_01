using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public NPCManager npcManager;
    public GameStateManager gameStateManager;
    private CharacterController characterController;
    private Vector3 moveDirection;             //�̵� ����

    public float range = 2.0f;  //�浹 ����

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);       //������ ������ �Ÿ� Ȯ��
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.TransformDirection(new Vector3(horizontalInput, 0, VerticalInput));
        moveDirection = move * moveSpeed;

        characterController.Move(moveDirection * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.E))
        {
            //�������� NPC ������Ʈ�� �����´� (TAG ���)
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            foreach(Collider collider in colliders)
            {
                if(collider.CompareTag("NPC"))
                {
                    Entity_DialogData.Param npcParam =
                        npcManager.GetParamData(collider.GetComponent<NPCActor>().npcNumber, gameStateManager.gameState);

                    if(npcParam != null)
                    {
                        Debug.Log($"Dialog: {npcParam.Dialog}");

                        if(npcParam.changeState > 0)
                        {
                            gameStateManager.gameState = npcParam.changeState;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("�ش��ϴ� �����Ͱ� �����ϴ�.");
                    }

                }
            }
        }
    }
}
