using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        // ESC Ű�� ���ȴ��� üũ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
            // �����Ϳ��� ���� ���� ���� �÷��� ��� ����
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // ����� ���ӿ��� ����
        Application.Quit();
#endif
    }
}
