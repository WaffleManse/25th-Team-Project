using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jellyPrefab;
    [SerializeField] private ScrollManager scrollManager;
    [SerializeField] private Transform jellyParent;
    [SerializeField] private float yOffset = 3f; // ÇÃ·§Æû À§·Î ¶ç¿ï ³ôÀÌ

    private bool spawned = false;

    void Update()
    {
        if (!spawned && scrollManager.ActivePlatforms.Count > 0)
        {
            SpawnJellies();
            spawned = true;
        }
    }

    void SpawnJellies()
    {
        foreach (GameObject platform in scrollManager.ActivePlatforms)
        {
            float width = platform.GetComponent<SpriteRenderer>().bounds.size.x;
            Vector3 start = platform.transform.position - new Vector3(width / 2f, 0, 0);
            float gap = width / 8f;

            for (int i = 0; i < 8; i++)
            {
                Vector3 jellyPos = start + new Vector3(gap * (i + 0.5f), yOffset, 0);
                Instantiate(jellyPrefab, jellyPos, Quaternion.identity, jellyParent);
            }
        }
    }
}
