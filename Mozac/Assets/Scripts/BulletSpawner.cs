using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //  ������ BulletSpawner ���� ������
    private float spawnRateMin = 0.2f; // �ּ� ���� �ֱ�
    private float spawnRateMax = 1f; // �ִ� ���� �ֱ�

    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�
    float rotSpeed = 100f; // BulletSpawner ȸ�� ����

    void Start()
    {
        timeAfterSpawn = 0f; // �ֱ� ���� ������ �����ð��� 0���� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
    }


    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            // ������ �ð� ����
            timeAfterSpawn = 0f;
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // ���� �Ѿ� ���� ������ spawnRateMin, spawnRateMin ���̿��� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMin);
        }
        // BulletSpawner�� Y�� �������� 1�ʿ� 100��ȸ��
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }
}
