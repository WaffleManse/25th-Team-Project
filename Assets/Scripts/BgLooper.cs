using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    [Header("��� ����")]
    public GameObject[] backgroundPrefabs; // ����� ��� �̹��� ������ (4��)
    public float backgroundSpeed = 5f; // ��� �̵� �ӵ�

    [Header("���� ����")]
    public GameObject[] platformPrefabs; // ����� ���� �̹��� ������ (4��)
    public float platformSpeed = 7f; // ���� �̵� �ӵ�
    public Transform platformParent; // ���� ������Ʈ���� ����� �θ� Transform

    [Header("��ֹ� ����")]
    public GameObject[] obstaclePrefabs; // ��ֹ� �̹��� ������ (2��)
    public float obstacleSpawnInterval = 2f; // ��ֹ� ���� ����
    public float obstacleSpawnXPosition = 20f; // ��ֹ��� ������ X ��ġ
    public Transform obstacleParent; // ��ֹ� ������Ʈ���� ����� �θ� Transform

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
            Debug.LogError("��� �������� ��Ȯ�� 4�� �����ؾ� �մϴ�.");
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

            // ���� ������ �̵��� ����� ������ ������ ���ġ
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
            Debug.LogError("���� �������� ��Ȯ�� 4�� �����ؾ� �մϴ�.");
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

            // ���� ������ �̵��� ������ ������ ������ ���ġ
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
            activeObstacles[i].transform.Translate(Vector3.left * platformSpeed * Time.deltaTime); // ���ǰ� ������ �ӵ��� �̵�

            // ȭ�� ������ ���� ��ֹ� ����
            if (activeObstacles[i].transform.position.x < -10f) // ������ ���� ��ġ ����
            {
                Destroy(activeObstacles[i]);
                activeObstacles.RemoveAt(i);
                i--; // ����Ʈ ũ�Ⱑ �پ����Ƿ� �ε��� ����
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
    //        float widthOfBgObject = ((BoxCollider2D)collision).size.x;//������ ���� ���� �ȵ� �ݶ��̴� ����.(������ x�� 1.7)
    //        //widthOfBgObject = widthOfBgObject + widthOfBgObject * 0.7f;

    //        Vector3 pos = collision.transform.position;

    //        pos.x += (widthOfBgObject * numBg);
    //        collision.transform.position = pos;
    //        return;
    //    }
    //}
}
