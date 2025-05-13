using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    [Header("배경 설정")]
    public GameObject[] backgroundPrefabs; // 연결된 배경 이미지 프리팹 (4개)
    public float backgroundSpeed = 5f; // 배경 이동 속도

    [Header("발판 설정")]
    public GameObject[] platformPrefabs; // 연결된 발판 이미지 프리팹 (4개)
    public float platformSpeed = 7f; // 발판 이동 속도
    public Transform platformParent; // 발판 오브젝트들을 묶어둘 부모 Transform

    [Header("장애물 설정")]
    public GameObject[] obstaclePrefabs; // 장애물 이미지 프리팹 (2개)
    public float obstacleSpawnInterval = 2f; // 장애물 생성 간격
    public float obstacleSpawnXPosition = 20f; // 장애물이 생성될 X 위치
    public Transform obstacleParent; // 장애물 오브젝트들을 묶어둘 부모 Transform

    private List<GameObject> activeBackgrounds = new List<GameObject>();
    private List<GameObject> activePlatforms = new List<GameObject>();
    private List<GameObject> activeObstacles = new List<GameObject>();

    private float nextObstacleSpawnTime;
    private float platformWidth;
    private float backgroundWidth;

    void Start()
    {
        InitializeBackground();
        InitializePlatforms();
        nextObstacleSpawnTime = Time.time + obstacleSpawnInterval;
    }

    void Update()
    {
        MoveBackgrounds();
        MovePlatforms();
        SpawnObstacles();
        MoveObstacles();
    }

    void InitializeBackground()
    {
        if (backgroundPrefabs.Length != 4)
        {
            Debug.LogError("배경 프리팹은 정확히 4개 연결해야 합니다.");
            return;
        }

        backgroundWidth = backgroundPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x;
        for (int i = 0; i < 4; i++)
        {
            GameObject bg = Instantiate(backgroundPrefabs[i], new Vector3(i * backgroundWidth, 0, 0), Quaternion.identity);
            activeBackgrounds.Add(bg);
        }
    }

    void MoveBackgrounds()
    {
        for (int i = 0; i < activeBackgrounds.Count; i++)
        {
            activeBackgrounds[i].transform.Translate(Vector3.left * backgroundSpeed * Time.deltaTime);

            // 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치
            if (activeBackgrounds[i].transform.position.x < -backgroundWidth)
            {
                int lastIndex = (i - 1 + activeBackgrounds.Count) % activeBackgrounds.Count;
                activeBackgrounds[i].transform.position = new Vector3(activeBackgrounds[lastIndex].transform.position.x + backgroundWidth, 0, 0);
            }
        }
    }

    void InitializePlatforms()
    {
        if (platformPrefabs.Length != 4)
        {
            Debug.LogError("발판 프리팹은 정확히 4개 연결해야 합니다.");
            return;
        }

        platformWidth = platformPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x;
        for (int i = 0; i < 4; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[i], new Vector3(i * platformWidth, -3.5f, 0), Quaternion.identity);
            if (platformParent != null)
            {
                platform.transform.SetParent(platformParent);
            }
            activePlatforms.Add(platform);
        }
    }

    void MovePlatforms()
    {
        for (int i = 0; i < activePlatforms.Count; i++)
        {
            activePlatforms[i].transform.Translate(Vector3.left * platformSpeed * Time.deltaTime);

            // 왼쪽 끝으로 이동한 발판을 오른쪽 끝으로 재배치
            if (activePlatforms[i].transform.position.x < -platformWidth)
            {
                int lastIndex = (i - 1 + activePlatforms.Count) % activePlatforms.Count;
                activePlatforms[i].transform.position = new Vector3(activePlatforms[lastIndex].transform.position.x + platformWidth, -3.5f, 0);
            }
        }
    }

    void SpawnObstacles()
    {
        if (Time.time >= nextObstacleSpawnTime)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject newObstacle = Instantiate(obstaclePrefabs[randomIndex], new Vector3(obstacleSpawnXPosition, -3f, 0), Quaternion.identity);
            if (obstacleParent != null)
            {
                newObstacle.transform.SetParent(obstacleParent);
            }
            activeObstacles.Add(newObstacle);
            nextObstacleSpawnTime = Time.time + obstacleSpawnInterval;
        }
    }

    void MoveObstacles()
    {
        for (int i = 0; i < activeObstacles.Count; i++)
        {
            activeObstacles[i].transform.Translate(Vector3.left * platformSpeed * Time.deltaTime); // 발판과 동일한 속도로 이동

            // 화면 밖으로 나간 장애물 제거
            if (activeObstacles[i].transform.position.x < -10f) // 적절한 제거 위치 설정
            {
                Destroy(activeObstacles[i]);
                activeObstacles.RemoveAt(i);
                i--; // 리스트 크기가 줄었으므로 인덱스 조정
            }
        }
    }
    //public float numBg = 5;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("Triggered: " + collision.name);

    //    if (collision.CompareTag("Background"))
    //    {
    //        float widthOfBgObject = ((BoxCollider2D)collision).size.x;//스케일 값이 적용 안된 콜라이더 넓이.(스케일 x는 1.7)
    //        //widthOfBgObject = widthOfBgObject + widthOfBgObject * 0.7f;

    //        Vector3 pos = collision.transform.position;

    //        pos.x += (widthOfBgObject * numBg);
    //        collision.transform.position = pos;
    //        return;
    //    }
    //}
}
