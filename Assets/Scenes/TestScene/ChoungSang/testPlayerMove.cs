using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMove : MonoBehaviour
{

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1f, 0, 0) * Speed * Time.deltaTime;
    }
}
