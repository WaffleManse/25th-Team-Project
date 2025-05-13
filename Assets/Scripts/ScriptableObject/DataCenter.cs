using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ν�����â���� �ٲ㼭 �׽�Ʈ���� �ݵ�� ���¸����� �����ּ���<br/>
/// ��������ο� <br/>
/// 1.[SerializeField] <br/>
/// 2.private DataCenter dataCenter; <br/>
/// ���� �����ö� �ݵ�� awake() start() ���Ŀ� ����Ұ�<br/>
/// ����)<br/>void Start()<br/>{<br/>int A = dataCenter.basicSpeed;<br/><br/>}
/// </summary>
[CreateAssetMenu(fileName = "DataCenter", menuName = "ScriptableObject/Data", order = 1)]
public class DataCenter : ScriptableObject
{
    //�÷��̾� �⺻ ü��
    [Header("�÷��̾� ���� ü��")]
    [Tooltip("���� �����ϸ� �÷��̾� ���� ü���� �ٲߴϴ�")]
    [SerializeField]
    private int basicLife = 5;
    public int BasicLife { get { return basicLife; } }

    //�÷��̾� �⺻ �̵��ӵ�
    [Header("�÷��̾� �⺻ �̵��ӵ�")]
    [Tooltip("")]
    [SerializeField]
    private int basicSpeed = 5;
    public int BasicSpeed { get { return basicSpeed; } }

    //�÷��̾� ���� ����
    [Header("�÷��̾� ���� ����")]
    [Tooltip("")]
    [SerializeField]
    private int basicJumpHeight = 5;
    public int BasicJumpHeight { get { return basicJumpHeight; } }

    //�÷��̾� �ִ����� Ƚ��
[Header("�÷��̾� �ִ����� Ƚ��")]
    [Tooltip("")]
    [SerializeField]
    private int maxJumpCount = 2;
    public int MaxJumpCount { get{ return maxJumpCount; } }

    //���� ����
    [Header("���� ����")]
    [Tooltip("")]
    [SerializeField]
    private int jelly  = 10;
    public int Jelly  { get{ return jelly ; } }



    //�̰����ʹ� ��ֹ��� ���� ���̴�.
    //����������������


    //��ֹ��� �����ϴ� hp��
    [Header("��ֹ��� �����ϴ� HP")]
    [Tooltip("")]
    [SerializeField]
    private int obstacleDamage = 1;
    public int ObstacleDamage { get { return obstacleDamage; } }


    //�׳� �迭�� �ѹ��� ���� �ұ�?�̰� ���� 1���̳����� ���� 2���� ������ �ι�����ؾ��ҰŰ�����;
    //��ֹ� 1���� ����
    [Header("��ֹ� 1���� ����")]
    [Tooltip("")]
    [SerializeField]
    private int obstacleFloorOne = 4; //�÷��̾� �������� -1
    public int ObstacleFloorOne { get { return obstacleFloorOne; } }

    //��ֹ� 2���� ����
    [Header("��ֹ� 2���� ����")]
    [Tooltip("")]
    [SerializeField]
    private int obstacleFloorTwo = 8;  //�÷��̾� �������� -2
    public int ObstacleFloorTwo { get { return obstacleFloorTwo; } }

    //��ֹ��� ���� ����
    [Header("��ֹ��� ���� ����")]
    [Tooltip("")]
    [SerializeField]
    private int obstacleSpawnInterval = 1;
    public int ObstacleSpawnInterval { get { return obstacleSpawnInterval; } }

    

}

#region ���̵�����
/*
�⺻ ��� 5;
�⺻ ���ǵ� ?;
��������100 ;


ĸ��ȭ ��� ����
[Header("")]
    [Tooltip("")]
    [SerializeField]
    private int  = ;
    public int  { get{ return ; } }


*/
#endregion

