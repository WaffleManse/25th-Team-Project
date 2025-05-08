using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void EnterGameStart()
    {
        SceneManager.LoadScene("MainScene");
    }


}
