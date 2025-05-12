using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sct : MonoBehaviour
{
    [SerializeField]
    private DataCenter datacenter;
    // Start is called before the first frame update
    void Start()
    {
        int A = datacenter.ObstacleDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
