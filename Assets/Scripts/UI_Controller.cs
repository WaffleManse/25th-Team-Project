using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField]
    private DataCenter dataCenter;


    public bool IsDead = false;
    public GameObject ResultUI;
    public void Result()
    {

        if (IsDead = true)
        {
            ResultUI.SetActive(true);
        }
    }


}
