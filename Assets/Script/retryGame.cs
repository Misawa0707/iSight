using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class retryGame : MonoBehaviour
{

    public GameObject player;
    public GameObject OnPanel;
    private bool pauseGame = true;
    //  batteryUIのスクリプト
    public PlayerController playerBattery;

    void Start()
    {
        OnUnPause();
        playerBattery = playerBattery.GetComponent<PlayerController>();
    }

    public void Update()
    {
        //Escを押したかどうか
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                OnPause();
             
            }
            else
            {
                OnUnPause();
              
            }
        }
    }

    public void OnPause()
    {
        // Menuをtrueにする
        OnPanel.SetActive(true);      
        Time.timeScale = 0;
        pauseGame = true;
        FirstPersonController fpc = player.GetComponent<FirstPersonController>();
        fpc.enabled = false;
        // 標準モード
        Cursor.lockState = CursorLockMode.None;
        // カーソル表示
        Cursor.visible = true;
        //減りを止める
        playerBattery.Flg = false;     
    }

    public void OnUnPause()
    {
        // Menuをfalseにする
        OnPanel.SetActive(false);      
        Time.timeScale = 1;
        pauseGame = false;
        FirstPersonController fpc = player.GetComponent<FirstPersonController>();
        fpc.enabled = true;
        // カーソル表示
        Cursor.visible = false;
        //減りの再開
        playerBattery.Flg = true;
    }

    public void OnRetry()
    {
        //リセット
        SceneManager.LoadScene("Play2");
    }

    public void OnReturn()
    {
        //ゲームに戻る
        OnUnPause();
        Cursor.visible = false;
    }

    public void OnTitle()
    {
        //タイトルに戻る
        SceneManager.LoadScene("Title");
    }
}