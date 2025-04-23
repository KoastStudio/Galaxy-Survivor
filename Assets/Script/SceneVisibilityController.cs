using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneVisibilityController : MonoBehaviour
{
    public GameObject childObject; // 플레이어의 자식 오브젝트

    private void Start()
    {
        // 현재 씬에 따라 자식 오브젝트의 활성화 상태 결정
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Space")
        {
            childObject.SetActive(true); // 씬 A에서 활성화
        }
        else if (currentScene == "InsideShip")
        {
            childObject.SetActive(false); // 씬 B에서 비활성화
        }
    }

    private void Update()
    {
        // 씬이 변경될 때마다 자식 오브젝트의 활성화 상태 업데이트
        if (Input.GetKeyDown(KeyCode.F)) // 예시로 L키를 눌러서 씬을 변경
        {
            string nextScene = SceneManager.GetActiveScene().name == "Space" ? "InsideShip" : "Space";
            SceneManager.LoadScene(nextScene);
        }

        // 필요에 따라 추가적인 로직을 넣을 수 있습니다.
    }
}
