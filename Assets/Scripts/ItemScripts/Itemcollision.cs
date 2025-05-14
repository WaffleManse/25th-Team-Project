
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 반드시 플레이어에 PLayer 태그 달아주세요
/// 아이템은 추상클래스로 만들었으며 아이템의 추가 기능을 만들때 itemcollision 클래스를 상속받고
/// override로 덮어서 메시지를 출력해주세요 먹으면 
/// 파괴로직만 만들고 기능을 추가하세요
/// </summary>
public abstract class Itemcollision : MonoBehaviour
{
    protected BoxCollider2D bc; // 자식 접근
    protected DataCenter dataCenter; // 자식 접근

    public ScoreCount scoreCount; // 스코어를 저장하는 장소
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
            Debug.LogError("ScoreCount가 연결되지 않았습니다!");
        }
    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어가 아이템 획득");
            scoreCount.AddScore(dataCenter.Jelly); //이거는 지우고 아이템의종류에서 판정해야할거같은데
            Destroy(gameObject);

        }

    }
    /// <summary>
    /// abstract로 구현을 강제했으니 반드시 기능은 자식클래스에서하세요
    /// </summary>
    protected abstract void ExecuteFunction(); //abstract로 구현을 강제했으니 반드시 기능은 자식클래스에서하세요
    

    

}


#region
/*


 
*/
#endregion