using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 이게 뭐냐면 발판에서 떨어뜨릴 위치거든요? 
/// 그래서 여기에서 오프셋설정한다음에 프리팹에 스크립트 붙여서 적용하면 돼요
/// 그러면 슬라이드 구현하려고 하면 이거 오프셋을 예를들어 4로하면 바닥에서 위로 4만큼y값 떨어지니까 되겠죠?
/// </summary>
public class ObstacleData : MonoBehaviour
{
    [Tooltip("이거 수정하면 플랫폼기준y값 올리는거임")]
    public float yOffset = 0f;
}
