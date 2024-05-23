using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public NPCManager npcManager;
    public GameStateManager gameStateManager;
    private CharacterController characterController;
    private Vector3 moveDirection;             //이동 방향

    public float range = 2.0f;  //충돌 범위

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);       //빨강색 원으로 거리 확인
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
            //오버랩된 NPC 오브젝트를 가져온다 (TAG 사용)
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
                        Debug.LogWarning("해당하는 데이터가 없습니다.");
                    }

                }
            }
        }
    }
}
