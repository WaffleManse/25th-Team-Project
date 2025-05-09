using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ݵ�� �÷��̾ PLayer �±� �޾��ּ���
/// �������� �߻�Ŭ������ ��������� �������� �߰� ����� ���鶧 itemcollision Ŭ������ ��ӹް�
/// override�� ��� �޽����� ������ּ��� ������ 
/// �ı������� ����� ����� �߰��ϼ���
/// </summary>
public class itemcollision : MonoBehaviour
{
    private BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ������ ȹ��");
            Destroy(gameObject);

        }

    }

    [Header ("ĸ��ȭ ���")]
    [Tooltip("����� ĸ��ȭ ȭ��ǥ �Ⱦ��°ɷ� ��?��?")]
    private int life = 0;
    public int Life { get { return Life; } }
}
