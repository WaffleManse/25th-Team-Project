using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Itemcollision
{
    protected override void ExecuteFunction()
    {
        Debug.Log(" 체력을 한칸 회복합니다.");
    }
}
