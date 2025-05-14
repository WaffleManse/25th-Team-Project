using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsDieCheck : MonoBehaviour
{

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("´ÔÁ×À¸½É");
            SceneManager.LoadScene("ResultScene");
            
        }
    }


}
