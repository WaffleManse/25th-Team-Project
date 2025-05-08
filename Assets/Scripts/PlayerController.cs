using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D; // rigidbody2d 컴포넌트 선언

    
    Vcector2 m_Movement; // 이동 방향 벡터

    public float Speed; // 이동 속도 

    public float Jump = 5f; // 점프 힘 

    public bool GodMode = false; // 신 모드
    public bool IsDead = false; // 죽음 상태


    private Vector2 moveVelocity; // 이동 방향 벡터




    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // rigidbody2d 컴포넌트 가져오기
        m_Movement = new Vector2(0, 0); // 이동 방향 초기화
    }

    private void Update()
    {

        transform.position += m_Movement * moveSpeed * Time.deltaTime; // 이동 처리

    }

    private void FixedUpdate()
    {
        velocity = new Vector2(moveVelocity.x, velocity.y); // 수평 이동 처리
    }
    

}
