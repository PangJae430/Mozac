using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //  생성할 BulletSpawner 원본 프리팹
    private float spawnRateMin = 0.2f; // 최소 생성 주기
    private float spawnRateMax = 1f; // 최대 생성 주기

    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간
    float rotSpeed = 100f; // BulletSpawner 회전 각도

    void Start()
    {
        timeAfterSpawn = 0f; // 최근 생성 이후의 누적시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
    }


    void Update()
    {
        //timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간 리셋
            timeAfterSpawn = 0f;
            // transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // 다음 총알 생성 간격을 spawnRateMin, spawnRateMin 사이에서 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMin);
        }
        // BulletSpawner가 Y축 기준으로 1초에 100도회전
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }
}
