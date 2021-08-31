using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToMainTransition : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //追加した
    //ボタンを押した時の処理
    public void PushButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}