using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // ��ֹ� �������� ������ �迭�Դϴ�. Inspector���� �Ҵ��ؾ� �մϴ�.
    public GameObject[] obstaclePrefabs;

    // ��ֹ� ���� ����
    public float obstacleSpawnRate = 1.5f; // �� ����

    // ���������� ��ֹ��� ������ �ð�
    private float lastSpawnTime = 0f;

    // ������ ������ ��ֹ��� ������ �����ϴ� ���� (0 �Ǵ� 1)
    private int nextObstacleType = 0;

    // ��ֹ��� ������ ��ġ�� x ��ǥ
    public float spawnPositionX = 10f;

    void Start()
    {
        // obstaclePrefabs �迭�� ��� ������ ���� �޽����� ǥ���ϰ� ��ũ��Ʈ�� ��Ȱ��ȭ�մϴ�.
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            Debug.LogError("Obstacle prefabs are not assigned!");
            this.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
            return;
        }
    }

    void Update()
    {
        // ���� �ð��� ������ ���� �ð��� ���̰� ��ֹ� ���� ���ݺ��� ũ�� ��ֹ��� �����մϴ�.
        if (Time.time > lastSpawnTime + obstacleSpawnRate)
        {
            SpawnObstacle();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnObstacle()
    {
        // ������ ������ ��ֹ��� �������� �����ɴϴ�.
        GameObject obstaclePrefab = obstaclePrefabs[nextObstacleType];

        // ��ֹ��� ������ ��ġ�� �����մϴ�.
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0f, 0f); // x�� ���� �����ϰ� ����

        // ��ֹ��� �����մϴ�.
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // ���� ��ֹ� ������ �����մϴ� (0�� 1�� ������ ����).
        nextObstacleType = 1 - nextObstacleType;
    }
}
