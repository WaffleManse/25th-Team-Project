
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ݵ�� �÷��̾ PLayer �±� �޾��ּ���
/// �������� �߻�Ŭ������ ��������� �������� �߰� ����� ���鶧 itemcollision Ŭ������ ��ӹް�
/// override�� ��� �޽����� ������ּ��� ������ 
/// �ı������� ����� ����� �߰��ϼ���
/// </summary>
public abstract class Itemcollision : MonoBehaviour
{
    protected BoxCollider2D bc; // �ڽ� ����
    protected DataCenter dataCenter; // �ڽ� ����

    public ScoreCount scoreCount; // ���ھ �����ϴ� ���
    //public ReadScoreUI readScoreUI;
    protected virtual void Start() // 
    {
        bc = GetComponent<BoxCollider2D>();
        if (scoreCount != null)
        {
            dataCenter = scoreCount.GetDataCenter();
        }
        else
        {
            Debug.LogError("ScoreCount�� ������� �ʾҽ��ϴ�!");
        }
    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ ������ ȹ��");
            scoreCount.AddScore(dataCenter.Jelly); //�̰Ŵ� ����� ���������������� �����ؾ��ҰŰ�����
            Destroy(gameObject);

        }

    }
    /// <summary>
    /// abstract�� ������ ���������� �ݵ�� ����� �ڽ�Ŭ���������ϼ���
    /// </summary>
    protected abstract void ExecuteFunction(); //abstract�� ������ ���������� �ݵ�� ����� �ڽ�Ŭ���������ϼ���
    

    

}


#region
/*


 
*/
#endregion