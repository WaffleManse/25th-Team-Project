using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid; // rigidbody2d 컴포넌트 선언
    private Vector3 moveVelocity; // 이동 방향 벡터

    public float Speed; // 이동 속도
    public float JumpPower = 2f; // 점프 힘
    public float JumpCount = 2; // 점프 횟수 카운트
    public float MaxJumpCount = 2; // 최대 점프 횟수 카운트
    public float Jump; // 점프 선언

    public bool IsJump = false; // 점프 t/f 확인
    public bool GodMode = false; // 신 모드 - QA 편의성 증가 목적
    public bool IsDead = false; // 죽음 상태

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // 입력 값 가져오기
        transform.position += new Vector3(0.7f, 0, 0);
        jump();


    }

    private void FixedUpdate()
    {
        moveVelocity = new Vector3(moveVelocity.x, moveVelocity.y); // 수평 이동 처리
    }

    void jump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsJump)
            {
                IsJump = true;
                rigid.AddForce(Vector3.up * Jump, ForceMode2D.Impulse);
            }

            if (JumpCount > 0)
            {
                rigid.velocity = Vector2.up * JumpPower;
                JumpCount--;
            }
        }


    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ground"))
        {
            IsJump = false;
        }

        if (JumpCount == 0)
        {
            JumpCount += MaxJumpCount;
        }
    }

}
