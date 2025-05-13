using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyItem : Itemcollision
{
    protected override void ExecuteFunction()
    {

        scoreCount.AddScore(dataCenter.Jelly); //Á©¸® Á¡¼ö¿¡¼­ ¹Þ¾Æ¿Â´Ù.
        Debug.Log("Á¡¼öÁ©¸®Á» Áàº¸¼À");

    }

}
