using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private DataCenter dataCenter;

    private int hp = 5;
    private int Hp;

    public void Awake()
    {
        Hp = hp + dataCenter.BasicLife; 
    }
}
