using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPloop : MonoBehaviour
{
    public int numGRcount = 50;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");

        if (collision.CompareTag("Ground"))
        {
            float widthOfBGobject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBGobject * numGRcount;
            collision.transform.position = pos;
            return; 

        }
    }
}
