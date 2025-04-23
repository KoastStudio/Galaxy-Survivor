using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static PlayerController;

public class ProximityInteraction : MonoBehaviour
{
    public GameObject uiObject; // UI 오브젝트 (비활성화 상태에서 시작)
    public Transform player; // 플레이어 또는 카메라
    public float interactionRange = 5f; // 상호작용 범위

    private void Update()
    {
        // 플레이어와 오브젝트의 거리 계산
        float distance = Vector3.Distance(player.position, transform.position);

        // 거리 내에 있으면 UI 활성화
        if (distance < interactionRange)
        {
            uiObject.SetActive(true);

            // F키를 눌렀을 때 다음 씬으로 전환
            if (Input.GetKeyDown(KeyCode.F))
            {
                // 다음 씬으로 전환
                SceneManager.LoadScene("InsideShip");
            }
        }
        else
        {
            uiObject.SetActive(false); // 범위를 벗어나면 UI 비활성화
        }
    }
}
