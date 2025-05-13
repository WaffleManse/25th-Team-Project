using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapSpawnData", menuName = "ScriptableObject/Mapdata", order = 0)]
public class MapDataCenter : ScriptableObject
{
    // 배경 설정부분
    [Header("배경 프리팹 리스트")]
    [Tooltip("배경으로 사용할 프리팹들을 설정")]
    [SerializeField]
    private List<GameObject> backgroundPrefabs;
    public List<GameObject> BackgroundPrefabs { get { return backgroundPrefabs; } }

    [Header("배경 스크롤 속도")]
    [Tooltip("배경이 왼쪽으로 움직이는 속도 수정가능")]
    [SerializeField]
    private float backgroundSpeed = 5f;
    public float BackgroundSpeed { get { return backgroundSpeed; } }

    [Header("배경 반복 개수")]
    [Tooltip("게임 시작 시 반복 생성할 배경 수 수정가능wn이거 바꾸면 오른쪽으로 얼마나더 배경생성하는지임")]
    [SerializeField]
    private int backgroundLoopCount = 4;
    public int BackgroundLoopCount { get { return backgroundLoopCount; } }

    //  발판 설정 부분
    [Header("발판 프리팹 리스트")]
    [Tooltip("플레이어가 밟을 수 있는 발판 프리팹들을 설정")]
    [SerializeField]
    private List<GameObject> platformPrefabs;
    public List<GameObject> PlatformPrefabs { get { return platformPrefabs; } }

    [Header("발판 스크롤 속도")]
    [Tooltip("발판이 왼쪽으로 움직이는 속도 수정가능이거 1000으로 하면 속도감 엄청남 ㄹㅇ")]
    [SerializeField]
    private float platformSpeed = 7f;
    public float PlatformSpeed { get { return platformSpeed; } }

    [Header("발판 높이 위치")]
    [Tooltip("발판이 배치될 Y 위치임 이거 수정하면 발판을 내리거나올릴수있음 생성위치를")]
    [SerializeField]
    private float platformHeight = -3.5f;
    public float PlatformHeight { get { return platformHeight; } }

    [Header("발판 반복 개수")]
    [Tooltip("게임 시작 시 생성할 발판 수 설정 \n 이거 수정하면 오른쪽으로 얼마나 더 생성할지고르는거임")]
    [SerializeField]
    private int platformLoopCount = 4;
    public int PlatformLoopCount { get { return platformLoopCount; } }

    [Header("발판 간격")]
    [Tooltip("발판 사이 간격을 조정")]
    [SerializeField]
    private float platformSpacing = 0f;
    public float PlatformSpacing { get { return platformSpacing; } }

    // 여기부턴 장애물 설정
    [Header("장애물 프리팹 리스트")]
    [Tooltip("게임 중 생성될 장애물 프리팹들을 등록해야함")]
    [SerializeField]
    private List<GameObject> obstaclePrefabs;
    public List<GameObject> ObstaclePrefabs { get { return obstaclePrefabs; } }

    [Header("장애물 생성 간격")]
    [Tooltip("장애물이 생성되는 시간 간격 간격")]
    [SerializeField]
    private float obstacleSpawnInterval = 2f;
    public float ObstacleSpawnInterval { get { return obstacleSpawnInterval; } }

    [Header("장애물 생성 위치 (X)")]
    [Tooltip("장애물이 생성될 X 좌표")]
    [SerializeField]
    private float obstacleSpawnXPosition = 20f;
    public float ObstacleSpawnXPosition { get { return obstacleSpawnXPosition; } }

    [Header("장애물 생성 위치 Y범위")]
    [Tooltip("장애물 생성시 Y 최솟값")]
    [SerializeField]
    private float obstacleMinY = -3f;
    public float ObstacleMinY { get { return obstacleMinY; } }

    [Tooltip("장애물 생성시 Y 최댓값")]
    [SerializeField]
    private float obstacleMaxY = 0f;
    public float ObstacleMaxY { get { return obstacleMaxY; } }

    [Header("최대 장애물 개수")]
    [Tooltip("맵에 동시에 존재할 수 있는 최대 장애물 개수를 조정가능")]
    [SerializeField]
    private int maxObstacleCount = 10;
    public int MaxObstacleCount { get { return maxObstacleCount; } }

    // 잡동사니
    [Header("오브젝트 제거 위치")]
    [Tooltip("이거바꾸면 X 좌표보다 왼쪽으로 이동하면 제거됨")]
    [SerializeField]
    private float objectDestroyXPosition = -10f;
    public float ObjectDestroyXPosition { get { return objectDestroyXPosition; } }

    [Header("스크롤 방향")]
    [Tooltip("배경, 발판, 장애물이 움직이는 방향, 왼쪽 오른쪽 바꿀수있음 ")]
    [SerializeField]
    private Vector3 scrollDirection = Vector3.left;
    public Vector3 ScrollDirection { get { return scrollDirection; } }

    [Header("(버그많음수정중임)전체 배율")]
    [Tooltip("이거 한번에 크기 바꾸는건데")]
    [SerializeField]
    private float scaleMultiplier = 1f;
    public float ScaleMultiplier { get { return scaleMultiplier; } }
}
