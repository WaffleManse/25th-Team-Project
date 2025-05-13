using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 인스펙터창에서 바꿔서 테스트한후 반드시 에셋리셋을 눌러주세요<br/>
/// 변수선언부에 <br/>
/// 1.[SerializeField] <br/>
/// 2.private DataCenter dataCenter; <br/>
/// 값을 꺼내올땐 반드시 awake() start() 이후에 사용할것<br/>
/// 예시)<br/>void Start()<br/>{<br/>int A = dataCenter.basicSpeed;<br/><br/>}
/// </summary>
[CreateAssetMenu(fileName = "DataCenter", menuName = "ScriptableObject/Data", order = 1)]
public class DataCenter : ScriptableObject
{
    //플레이어 기본 체력
    [Header("플레이어 기초 체력")]
    [Tooltip("값을 수정하면 플레이어 기초 체력을 바꿉니다")]
    [SerializeField]
    private int basicLife = 5;
    public int BasicLife { get { return basicLife; } }

    //플레이어 기본 이동속도
    [Header("플레이어 기본 이동속도")]
    [Tooltip("")]
    [SerializeField]
    private int basicSpeed = 5;
    public int BasicSpeed { get { return basicSpeed; } }

    //플레이어 점프 높이
    [Header("플레이어 점프 높이")]
    [Tooltip("")]
    [SerializeField]
    private int basicJumpHeight = 5;
    public int BasicJumpHeight { get { return basicJumpHeight; } }

    //플레이어 최대점프 횟수
[Header("플레이어 최대점프 횟수")]
    [Tooltip("")]
    [SerializeField]
    private int maxJumpCount = 2;
    public int MaxJumpCount { get{ return maxJumpCount; } }

    //젤리 점수
    [Header("젤리 점수")]
    [Tooltip("")]
    [SerializeField]
    private int jelly  = 10;
    public int Jelly  { get{ return jelly ; } }



    //이곳부터는 장애물에 관한 것이다.
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓


    //장애물이 차감하는 hp값
    [Header("장애물이 차감하는 HP")]
    [Tooltip("")]
    [SerializeField]
    private int obstacleDamage = 1;
    public int ObstacleDamage { get { return obstacleDamage; } }


    //그냥 배열로 한번에 만들어서 할까?이게 언제 1단이나오고 언제 2단이 나올지 두번계산해야할거같은디;
    //장애물 1단의 높이
    [Header("장애물 1단의 높이")]
    [Tooltip("")]
    [SerializeField]
    private int obstacleFloorOne = 4; //플레이어 점프높이 -1
    public int ObstacleFloorOne { get { return obstacleFloorOne; } }

    //장애물 2단의 높이
    [Header("장애물 2단의 높이")]
    [Tooltip("")]
    [SerializeField]
    private int obstacleFloorTwo = 8;  //플레이어 점프높이 -2
    public int ObstacleFloorTwo { get { return obstacleFloorTwo; } }

    //장애물의 생성 간격
    [Header("장애물의 생성 간격")]
    [Tooltip("")]
    [SerializeField]
    private int obstacleSpawnInterval = 1;
    public int ObstacleSpawnInterval { get { return obstacleSpawnInterval; } }

    

}

#region 더미데이터
/*
기본 목숨 5;
기본 스피드 ?;
젤리점수100 ;


캡슐화 기몬 형태
[Header("")]
    [Tooltip("")]
    [SerializeField]
    private int  = ;
    public int  { get{ return ; } }


*/
#endregion

