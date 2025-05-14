using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [Header("스크립터블 오브젝트 연결")]
    [SerializeField]
    private MapDataCenter mapdataCenter;

    [Header("부모 오브젝트 연결")]
    [SerializeField]
    private Transform platformParent;
    [SerializeField]
    private Transform obstacleParent;

    // SO = scriptableobject의 약자 기니까 편의성위해 줄여서 앞으론So
    //맵데이터 SO에는 차가/추가된 정보를 담고있는데
    //그걸 이제 리스트화 해올거임 여기까지 이해ㅇㅋ? 민혁님이 저번에 물어보셨던 초기화의 개념입니다 
    //데이터 센터에는 정보만 담겨있고 그걸 여기서 초기화를 해줘야 이제 저희가 쓸수있어요
    //선언만하면 우리눈에만 안보이는거지 컴퓨터 내부에는 진짜 막그냥알수없는 수로 이루어져 있거든요?15415145이런게 쓰레기값이 저장이되고
    //이걸 값을 넣어줘야 15415145 이 값이 없어지고 저희가 원하는 값이 들어가는데, 이걸 우리는 초기화라고 부르는거에요
    private List<GameObject> activeBackgrounds = new List<GameObject>();
    private List<GameObject> activePlatforms = new List<GameObject>();
    private List<GameObject> activeObstacles = new List<GameObject>();

    private float nextObstacleSpawnTime; //다시한번 짚고가면 여기는 그냥 선언만 한 상태 쓰레기값이 들어있는거고 밑에 start함수에서 초기화

    void Start()
    {
        InitBackgrounds();
        InitPlatforms();
        //Time.time은 게임 실행후 부터 현재까지 의 걸린 시간이고 
        //현재 누적시간+SO에서 설정한 장애물간격시간
        // 그냥 다음생성시간 = 장애물생성간격 하면 되는거아님?
        //안됨 이거는 계속 생성하는게아니라 현재 기점으로 다음 생성 시간은 언제할지를 정해주는거임즉 현재가14면 다음은 18 다음은 24 이걸 계속 적어줌

        nextObstacleSpawnTime = Time.time + mapdataCenter.ObstacleSpawnInterval; 
    }

    void Update()
    {
        ScrollObjects(activeBackgrounds, mapdataCenter.BackgroundSpeed, mapdataCenter.BackgroundLoopCount);
        ScrollObjects(activePlatforms, mapdataCenter.PlatformSpeed, mapdataCenter.PlatformLoopCount, mapdataCenter.PlatformHeight);
        ScrollAndCullObstacles();
        SpawnObstacleIfNeeded();
    }

    //  배경 생성
    // Init은 초기화의 의미를 가지는데 보통 변수든 함수든 이름을 이렇게 붙이면,
    // 앞으로 생성 배치등록 등등 뭔가를 세팅한다는 의미를 추측할수있는거임
    // 개발자들사이에서 이게 암묵적 약속같은거라 모르면 알면 좋음(모름 걍 뇌피셜 추측임 시멘틱버저닝처럼 예측할수있어서 적어는 뒀음)
    void InitBackgrounds()
    {
        float width = GetWidth(mapdataCenter.BackgroundPrefabs[0]);

        //백그라운드 루프 개수를 우리가SO에서 설정하면 그걸 받아와서 for문한번돌리고 검사하는거임
        //몇개를 할건지 
        for (int i = 0; i < mapdataCenter.BackgroundLoopCount; i++) 
        {
            //생성되는위치가 안겹치게 width만큼 계속 띄워주는거임 ㅇㅋ?그니까 맵이 안짤리고 계속 루프되는거임
            Vector3 pos = new Vector3(i * width, 0, 0);

            //반복문 돌릴때마다 한개씩 생성할건데
            //여기서 우리의 옛날 기억을 떠올려야함
            //아니 1을 2로나누면 0.5고 애초에 나눌수가 없는데? 가아니라 못나누니까 그냥 나머지가 1로나옴 ㅇㅋ?
            //Quaternion.identity 이거는 vector.zero 처럼 그냥 회전을 안한상태라는 뜻임
            GameObject bg = Instantiate(mapdataCenter.BackgroundPrefabs[i % mapdataCenter.BackgroundPrefabs.Count], pos, Quaternion.identity);
            activeBackgrounds.Add(bg);
        }
    }

    float GetWidth(GameObject obj)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        return sr != null ? sr.bounds.size.x * mapdataCenter.ScaleMultiplier : 1f;
    }

    // 발판 초기화
    void InitPlatforms()
    {
        float width = GetWidth(mapdataCenter.PlatformPrefabs[0]);

        for (int i = 0; i < mapdataCenter.PlatformLoopCount; i++)
        {
            Vector3 pos = new Vector3(i * width + i * mapdataCenter.PlatformSpacing, mapdataCenter.PlatformHeight, 0);
            GameObject platform = Instantiate(mapdataCenter.PlatformPrefabs[i % mapdataCenter.PlatformPrefabs.Count], pos, Quaternion.identity);
            if (platformParent != null) platform.transform.SetParent(platformParent);
            activePlatforms.Add(platform);
        }
    }

    //  오브젝트 스크롤 (배경/발판)
    void ScrollObjects(List<GameObject> list, float speed, int loopCount, float fixedY = 0f)
    {
        if (list.Count == 0) return;

        float width = GetWidth(list[0]);
        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.Translate(mapdataCenter.ScrollDirection * speed * Time.deltaTime);

            if (list[i].transform.position.x < -width)
            {
                int lastIndex = (i - 1 + list.Count) % list.Count;
                float newX = list[lastIndex].transform.position.x + width + mapdataCenter.PlatformSpacing;
                list[i].transform.position = new Vector3(newX, fixedY, 0);
            }
        }
    }

    float GetObstacleYOffset(GameObject obstacle)
    {
        // 1. ObstacleData가 있다면 yOffset 값을 우선 사용
        ObstacleData data = obstacle.GetComponent<ObstacleData>();
        if (data != null)
            return data.yOffset;

        // 2. 없으면 SpriteRenderer 기준으로 기본 높이 계산
        SpriteRenderer sr = obstacle.GetComponent<SpriteRenderer>();
        return sr != null ? sr.bounds.extents.y : 0f;
    }



    void SpawnObstacleIfNeeded()
    {
        if (Time.time < nextObstacleSpawnTime) return;
        if (activeObstacles.Count >= mapdataCenter.MaxObstacleCount) return;
        if (mapdataCenter.ObstaclePrefabs == null || mapdataCenter.ObstaclePrefabs.Count == 0) return;

        int index = Random.Range(0, mapdataCenter.ObstaclePrefabs.Count);
        GameObject prefab = mapdataCenter.ObstaclePrefabs[index];

        // 1. 먼저 장애물 생성 (위치는 임시로 Vector3.zero)
        GameObject obstacle = Instantiate(prefab, Vector3.zero, Quaternion.identity);

        // 2. 생성된 오브젝트에서 yOffset 계산
        float y = mapdataCenter.PlatformHeight + GetObstacleYOffset(obstacle);

        // 3. 최종 위치 적용
        Vector3 spawnPos = new Vector3(mapdataCenter.ObstacleSpawnXPosition, y, 0);
        obstacle.transform.position = spawnPos;

        // 4. 부모 설정 (부모가 있을 경우)
        if (obstacleParent != null)
            obstacle.transform.SetParent(obstacleParent);

        // 5. 리스트에 추가 및 다음 생성 시간 갱신
        activeObstacles.Add(obstacle);
        nextObstacleSpawnTime = Time.time + mapdataCenter.ObstacleSpawnInterval;
    }


   

    void ScrollAndCullObstacles()
    {
        for (int i = 0; i < activeObstacles.Count; i++)
        {
            GameObject obs = activeObstacles[i];
            obs.transform.Translate(mapdataCenter.ScrollDirection * mapdataCenter.PlatformSpeed * Time.deltaTime);

            if (obs.transform.position.x < mapdataCenter.ObjectDestroyXPosition)
            {
                Destroy(obs);
                activeObstacles.RemoveAt(i);
                i--;
            }
        }
    }


    public List<GameObject> ActivePlatforms => activePlatforms;//젤리스포너사용을위한참조
}
