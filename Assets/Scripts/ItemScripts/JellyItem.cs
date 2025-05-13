using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyItem : Itemcollision
{
    protected override void ExecuteFunction()
    {

        scoreCount.AddScore(dataCenter.Jelly); //젤리 점수에서 받아온다.

    }

}
