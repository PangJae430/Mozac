using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���̺귯��
using UnityEngine.SceneManagement; // �� ���� ���� ���̺귯��

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime; // ���� �ð�
    private bool isGameover; // ���� ���� ����

    void Start()
    {
        // ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        // ���ӿ����� �ƴ� ����
        if(!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            // ���ӿ����� ���¿��� RŰ�� ���� ���
            if(Input.GetKeyDown(KeyCode.R))
            {
                // SmapleScene ���� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    // ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        isGameover = true; // ���� ���¸� ���ӿ��� ���·� ��ȯ
        gameoverText.SetActive(true); // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ

        float bestTime = PlayerPrefs.GetFloat("BestTime"); // BestTime Ű�� ����� ���������� �ְ� ��� ��������

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if(surviveTime>bestTime)
        {
            bestTime = surviveTime; // �ְ� ��� ���� ���� ���� �ð� ������ ����
            PlayerPrefs.SetFloat("BestTime", bestTime); // ����� �ְ� ����� BestTime Ű�� ����
        }
        // �ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "Best Time: " + (int)bestTime;
    }
}
