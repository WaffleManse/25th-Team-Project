using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 반드시 플레이어에 PLayer 태그 달아주세요
/// 아이템은 추상클래스로 만들었으며 아이템의 추가 기능을 만들때 itemcollision 클래스를 상속받고
/// override로 덮어서 메시지를 출력해주세요 먹으면 
/// 파괴로직만 만들고 기능을 추가하세요
/// </summary>
public class itemcollision : MonoBehaviour
{
    private BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어가 아이템 획득");
            Destroy(gameObject);

        }

    }

    [Header ("캡슐화 방식")]
    [Tooltip("저희는 캡슐화 화살표 안쓰는걸로 협?의?")]
    private int life = 0;
    public int Life { get { return Life; } }
}
