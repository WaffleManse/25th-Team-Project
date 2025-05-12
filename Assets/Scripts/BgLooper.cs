using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public float numBg = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("Background"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;//������ ���� ���� �ȵ� �ݶ��̴� ����.(������ x�� 1.7)
            //widthOfBgObject = widthOfBgObject + widthOfBgObject * 0.7f;
            
            Vector3 pos = collision.transform.position;

            pos.x += (widthOfBgObject * numBg);
            collision.transform.position = pos;
            return;
        }
    }
}
