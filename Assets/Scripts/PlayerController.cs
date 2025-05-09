using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid; // rigidbody2d 컴포넌트 선언


    public float Speed; // 이동 속도



    private Vector3 moveVelocity; // 이동 방향 벡터


    public float JumpPower = 7f; // 점프 힘
    public float jump; // 점프 선언 

    public bool IsJump = false; // 점프 t/f 확인

    public bool GodMode = false; // 신 모드
    public bool IsDead = false; // 죽음 상태

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // 입력 값 가져오기
        transform.position += new Vector3(0.7f, 0, 0);
        Jump();


    }

    private void FixedUpdate()
    {
        moveVelocity = new Vector3(moveVelocity.x, moveVelocity.y); // 수평 이동 처리
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsJump)
            {
                IsJump = false;
                rigid.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ground"))
        {
            IsJump = false;
        }
    }

}
