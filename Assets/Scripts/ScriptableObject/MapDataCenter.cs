using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapSpawnData", menuName = "ScriptableObject/Mapdata", order = 0)]
public class MapDataCenter : ScriptableObject
{
    // ��� �����κ�
    [Header("��� ������ ����Ʈ")]
    [Tooltip("������� ����� �����յ��� ����")]
    [SerializeField]
    private List<GameObject> backgroundPrefabs;
    public List<GameObject> BackgroundPrefabs { get { return backgroundPrefabs; } }

    [Header("��� ��ũ�� �ӵ�")]
    [Tooltip("����� �������� �����̴� �ӵ� ��������")]
    [SerializeField]
    private float backgroundSpeed = 5f;
    public float BackgroundSpeed { get { return backgroundSpeed; } }

    [Header("��� �ݺ� ����")]
    [Tooltip("���� ���� �� �ݺ� ������ ��� �� ��������wn�̰� �ٲٸ� ���������� �󸶳��� �������ϴ�����")]
    [SerializeField]
    private int backgroundLoopCount = 4;
    public int BackgroundLoopCount { get { return backgroundLoopCount; } }

    //  ���� ���� �κ�
    [Header("���� ������ ����Ʈ")]
    [Tooltip("�÷��̾ ���� �� �ִ� ���� �����յ��� ����")]
    [SerializeField]
    private List<GameObject> platformPrefabs;
    public List<GameObject> PlatformPrefabs { get { return platformPrefabs; } }

    [Header("���� ��ũ�� �ӵ�")]
    [Tooltip("������ �������� �����̴� �ӵ� ���������̰� 1000���� �ϸ� �ӵ��� ��û�� ����")]
    [SerializeField]
    private float platformSpeed = 7f;
    public float PlatformSpeed { get { return platformSpeed; } }

    [Header("���� ���� ��ġ")]
    [Tooltip("������ ��ġ�� Y ��ġ�� �̰� �����ϸ� ������ �����ų��ø������� ������ġ��")]
    [SerializeField]
    private float platformHeight = -3.5f;
    public float PlatformHeight { get { return platformHeight; } }

    [Header("���� �ݺ� ����")]
    [Tooltip("���� ���� �� ������ ���� �� ���� \n �̰� �����ϸ� ���������� �󸶳� �� �����������°���")]
    [SerializeField]
    private int platformLoopCount = 4;
    public int PlatformLoopCount { get { return platformLoopCount; } }

    [Header("���� ����")]
    [Tooltip("���� ���� ������ ����")]
    [SerializeField]
    private float platformSpacing = 0f;
    public float PlatformSpacing { get { return platformSpacing; } }

    // ������� ��ֹ� ����
    [Header("��ֹ� ������ ����Ʈ")]
    [Tooltip("���� �� ������ ��ֹ� �����յ��� ����ؾ���")]
    [SerializeField]
    private List<GameObject> obstaclePrefabs;
    public List<GameObject> ObstaclePrefabs { get { return obstaclePrefabs; } }

    [Header("��ֹ� ���� ����")]
    [Tooltip("��ֹ��� �����Ǵ� �ð� ���� ����")]
    [SerializeField]
    private float obstacleSpawnInterval = 2f;
    public float ObstacleSpawnInterval { get { return obstacleSpawnInterval; } }

    [Header("��ֹ� ���� ��ġ (X)")]
    [Tooltip("��ֹ��� ������ X ��ǥ")]
    [SerializeField]
    private float obstacleSpawnXPosition = 20f;
    public float ObstacleSpawnXPosition { get { return obstacleSpawnXPosition; } }

    [Header("��ֹ� ���� ��ġ Y����")]
    [Tooltip("��ֹ� ������ Y �ּڰ�")]
    [SerializeField]
    private float obstacleMinY = -3f;
    public float ObstacleMinY { get { return obstacleMinY; } }

    [Tooltip("��ֹ� ������ Y �ִ�")]
    [SerializeField]
    private float obstacleMaxY = 0f;
    public float ObstacleMaxY { get { return obstacleMaxY; } }

    [Header("�ִ� ��ֹ� ����")]
    [Tooltip("�ʿ� ���ÿ� ������ �� �ִ� �ִ� ��ֹ� ������ ��������")]
    [SerializeField]
    private int maxObstacleCount = 10;
    public int MaxObstacleCount { get { return maxObstacleCount; } }

    // �⵿���
    [Header("������Ʈ ���� ��ġ")]
    [Tooltip("�̰Źٲٸ� X ��ǥ���� �������� �̵��ϸ� ���ŵ�")]
    [SerializeField]
    private float objectDestroyXPosition = -10f;
    public float ObjectDestroyXPosition { get { return objectDestroyXPosition; } }

    [Header("��ũ�� ����")]
    [Tooltip("���, ����, ��ֹ��� �����̴� ����, ���� ������ �ٲܼ����� ")]
    [SerializeField]
    private Vector3 scrollDirection = Vector3.left;
    public Vector3 ScrollDirection { get { return scrollDirection; } }

    [Header("(���׸�����������)��ü ����")]
    [Tooltip("�̰� �ѹ��� ũ�� �ٲٴ°ǵ�")]
    [SerializeField]
    private float scaleMultiplier = 1f;
    public float ScaleMultiplier { get { return scaleMultiplier; } }
}
