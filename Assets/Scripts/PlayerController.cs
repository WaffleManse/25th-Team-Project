using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D; // rigidbody2d 컴포넌트 선언


    public float Speed; // 이동 속도

    private Rigidbody2D rb; 

    private Vector2 moveVelocity; // 이동 방향 벡터


    public float Jump = 5f; // 점프 힘 

    public bool GodMode = false; // 신 모드
    public bool IsDead = false; // 죽음 상태






    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // rigidbody2d 컴포넌트 가져오기
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // 입력 값 가져오기
        moveVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // 이동 방향 벡터 설정
        

    }

    private void FixedUpdate()
    {
        moveVelocity = new Vector2(moveVelocity.x, moveVelocity.y); // 수평 이동 처리
    }
    

}
