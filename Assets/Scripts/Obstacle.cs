using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // 장애물 프리팹을 저장할 배열입니다. Inspector에서 할당해야 합니다.
    public GameObject[] obstaclePrefabs;

    // 장애물 생성 간격
    public float obstacleSpawnRate = 1.5f; // 초 단위

    // 마지막으로 장애물을 생성한 시간
    private float lastSpawnTime = 0f;

    // 다음에 생성할 장애물의 유형을 추적하는 변수 (0 또는 1)
    private int nextObstacleType = 0;

    // 장애물이 생성될 위치의 x 좌표
    public float spawnPositionX = 10f;

    void Start()
    {
        // obstaclePrefabs 배열이 비어 있으면 에러 메시지를 표시하고 스크립트를 비활성화합니다.
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            Debug.LogError("Obstacle prefabs are not assigned!");
            this.enabled = false; // 스크립트 비활성화
            return;
        }
    }

    void Update()
    {
        // 현재 시간과 마지막 생성 시간의 차이가 장애물 생성 간격보다 크면 장애물을 생성합니다.
        if (Time.time > lastSpawnTime + obstacleSpawnRate)
        {
            SpawnObstacle();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnObstacle()
    {
        // 다음에 생성할 장애물의 프리팹을 가져옵니다.
        GameObject obstaclePrefab = obstaclePrefabs[nextObstacleType];

        // 장애물을 생성할 위치를 설정합니다.
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0f, 0f); // x를 조정 가능하게 만듦

        // 장애물을 생성합니다.
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // 다음 장애물 유형을 설정합니다 (0과 1을 번갈아 가며).
        nextObstacleType = 1 - nextObstacleType;
    }
}
