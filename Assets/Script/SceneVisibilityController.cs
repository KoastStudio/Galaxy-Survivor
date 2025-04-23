using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneVisibilityController : MonoBehaviour
{
    public GameObject childObject; // �÷��̾��� �ڽ� ������Ʈ

    private void Start()
    {
        // ���� ���� ���� �ڽ� ������Ʈ�� Ȱ��ȭ ���� ����
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Space")
        {
            childObject.SetActive(true); // �� A���� Ȱ��ȭ
        }
        else if (currentScene == "InsideShip")
        {
            childObject.SetActive(false); // �� B���� ��Ȱ��ȭ
        }
    }

    private void Update()
    {
        // ���� ����� ������ �ڽ� ������Ʈ�� Ȱ��ȭ ���� ������Ʈ
        if (Input.GetKeyDown(KeyCode.F)) // ���÷� LŰ�� ������ ���� ����
        {
            string nextScene = SceneManager.GetActiveScene().name == "Space" ? "InsideShip" : "Space";
            SceneManager.LoadScene(nextScene);
        }

        // �ʿ信 ���� �߰����� ������ ���� �� �ֽ��ϴ�.
    }
}
