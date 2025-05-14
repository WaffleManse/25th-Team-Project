using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [Header("��ũ���ͺ� ������Ʈ ����")]
    [SerializeField]
    private MapDataCenter mapdataCenter;

    [Header("�θ� ������Ʈ ����")]
    [SerializeField]
    private Transform platformParent;
    [SerializeField]
    private Transform obstacleParent;

    // SO = scriptableobject�� ���� ��ϱ� ���Ǽ����� �ٿ��� ������So
    //�ʵ����� SO���� ����/�߰��� ������ ����ִµ�
    //�װ� ���� ����Ʈȭ �ؿð��� ������� ���ؤ���? �������� ������ ����̴� �ʱ�ȭ�� �����Դϴ� 
    //������ ���Ϳ��� ������ ����ְ� �װ� ���⼭ �ʱ�ȭ�� ����� ���� ���� �����־��
    //�����ϸ� �츮������ �Ⱥ��̴°��� ��ǻ�� ���ο��� ��¥ ���׳ɾ˼����� ���� �̷���� �ְŵ��?15415145�̷��� �����Ⱚ�� �����̵ǰ�
    //�̰� ���� �־���� 15415145 �� ���� �������� ���� ���ϴ� ���� ���µ�, �̰� �츮�� �ʱ�ȭ��� �θ��°ſ���
    private List<GameObject> activeBackgrounds = new List<GameObject>();
    private List<GameObject> activePlatforms = new List<GameObject>();
    private List<GameObject> activeObstacles = new List<GameObject>();

    private float nextObstacleSpawnTime; //�ٽ��ѹ� ¤���� ����� �׳� ���� �� ���� �����Ⱚ�� ����ִ°Ű� �ؿ� start�Լ����� �ʱ�ȭ

    void Start()
    {
        InitBackgrounds();
        InitPlatforms();
        //Time.time�� ���� ������ ���� ������� �� �ɸ� �ð��̰� 
        //���� �����ð�+SO���� ������ ��ֹ����ݽð�
        // �׳� ���������ð� = ��ֹ��������� �ϸ� �Ǵ°žƴ�?
        //�ȵ� �̰Ŵ� ��� �����ϴ°Ծƴ϶� ���� �������� ���� ���� �ð��� ���������� �����ִ°����� ���簡14�� ������ 18 ������ 24 �̰� ��� ������

        nextObstacleSpawnTime = Time.time + mapdataCenter.ObstacleSpawnInterval; 
    }

    void Update()
    {
        ScrollObjects(activeBackgrounds, mapdataCenter.BackgroundSpeed, mapdataCenter.BackgroundLoopCount);
        ScrollObjects(activePlatforms, mapdataCenter.PlatformSpeed, mapdataCenter.PlatformLoopCount, mapdataCenter.PlatformHeight);
        ScrollAndCullObstacles();
        SpawnObstacleIfNeeded();
    }

    //  ��� ����
    // Init�� �ʱ�ȭ�� �ǹ̸� �����µ� ���� ������ �Լ��� �̸��� �̷��� ���̸�,
    // ������ ���� ��ġ��� ��� ������ �����Ѵٴ� �ǹ̸� �����Ҽ��ִ°���
    // �����ڵ���̿��� �̰� �Ϲ��� ��Ӱ����Ŷ� �𸣸� �˸� ����(�� �� ���Ǽ� ������ �ø�ƽ������ó�� �����Ҽ��־ ����� ����)
    void InitBackgrounds()
    {
        float width = GetWidth(mapdataCenter.BackgroundPrefabs[0]);

        //��׶��� ���� ������ �츮��SO���� �����ϸ� �װ� �޾ƿͼ� for���ѹ������� �˻��ϴ°���
        //��� �Ұ��� 
        for (int i = 0; i < mapdataCenter.BackgroundLoopCount; i++) 
        {
            //�����Ǵ���ġ�� �Ȱ�ġ�� width��ŭ ��� ����ִ°��� ����?�״ϱ� ���� ��©���� ��� �����Ǵ°���
            Vector3 pos = new Vector3(i * width, 0, 0);

            //�ݺ��� ���������� �Ѱ��� �����Ұǵ�
            //���⼭ �츮�� ���� ����� ���÷�����
            //�ƴ� 1�� 2�γ����� 0.5�� ���ʿ� �������� ���µ�? ���ƴ϶� �������ϱ� �׳� �������� 1�γ��� ����?
            //Quaternion.identity �̰Ŵ� vector.zero ó�� �׳� ȸ���� ���ѻ��¶�� ����
            GameObject bg = Instantiate(mapdataCenter.BackgroundPrefabs[i % mapdataCenter.BackgroundPrefabs.Count], pos, Quaternion.identity);
            activeBackgrounds.Add(bg);
        }
    }

    float GetWidth(GameObject obj)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        return sr != null ? sr.bounds.size.x * mapdataCenter.ScaleMultiplier : 1f;
    }

    // ���� �ʱ�ȭ
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

    //  ������Ʈ ��ũ�� (���/����)
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
        // 1. ObstacleData�� �ִٸ� yOffset ���� �켱 ���
        ObstacleData data = obstacle.GetComponent<ObstacleData>();
        if (data != null)
            return data.yOffset;

        // 2. ������ SpriteRenderer �������� �⺻ ���� ���
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

        // 1. ���� ��ֹ� ���� (��ġ�� �ӽ÷� Vector3.zero)
        GameObject obstacle = Instantiate(prefab, Vector3.zero, Quaternion.identity);

        // 2. ������ ������Ʈ���� yOffset ���
        float y = mapdataCenter.PlatformHeight + GetObstacleYOffset(obstacle);

        // 3. ���� ��ġ ����
        Vector3 spawnPos = new Vector3(mapdataCenter.ObstacleSpawnXPosition, y, 0);
        obstacle.transform.position = spawnPos;

        // 4. �θ� ���� (�θ� ���� ���)
        if (obstacleParent != null)
            obstacle.transform.SetParent(obstacleParent);

        // 5. ����Ʈ�� �߰� �� ���� ���� �ð� ����
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


    public List<GameObject> ActivePlatforms => activePlatforms;//���������ʻ������������
}
