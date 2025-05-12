using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigid; // rigidbody2d 컴포넌트 선언
    private Vector3 moveVelocity; // 이동 방향 벡터
    Animator animator; // 애니메이터 선언 

    public float Speed; // 이동 속도
    public float JumpPower = 5f; // 점프 힘
    public float JumpCount = 2; // 점프 횟수 카운트
    public float MaxJumpCount = 2; // 최대 점프 횟수 카운트
    public float Jump; // 점프 선언


    private Rigidbody2D rb; 

    private Vector2 moveVelocity; // 이동 방향 벡터


    public float Jump = 5f; // 점프 힘 

    public bool GodMode = false; // 신 모드
    public bool IsDead = false; // 죽음 상태


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // rigidbody2d 컴포넌트 가져오기
    }

    private void Update()
    {

        // 스페이스 입력시 점프가 나가는 코드
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsJump)
            {
                IsJump = false;
                rigid.AddForce(Vector3.up * Jump, ForceMode2D.Impulse);
            }

            if (JumpCount > 0)
            {
                rigid.velocity = Vector2.up * JumpPower;
                JumpCount--;
            }
        }



    }

    private void FixedUpdate()
    {

        // 땅과 충돌시 점프 카운트가 줄어드는 코드
        if (other.gameObject.name.Equals("Ground"))
        {
            IsJump = false;
        }

        if (JumpCount == 0)
        {
            JumpCount += MaxJumpCount;
        }

    }
    

    public void OnBoxCollider2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ground"))
        {
            IsJump = false;
        }
    }

}
