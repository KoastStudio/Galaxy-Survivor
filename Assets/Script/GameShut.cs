using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        // ESC 키가 눌렸는지 체크
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
            // 에디터에서 실행 중일 때는 플레이 모드 종료
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 게임에서 종료
        Application.Quit();
#endif
    }
}
