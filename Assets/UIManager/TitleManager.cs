using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Button StartBtn;
    [SerializeField] Button ContinueBtn;

    string firstSceneName = "WorldMap";
    void Start()
    {
        StartBtn.onClick.AddListener(() => { OnClickStartBtn(); });
        ContinueBtn.onClick.AddListener(() => { onClickContinueBtn(); });

        

        string sceneName = PlayerPrefs.GetString("LastScene");
        if (sceneName == "") ContinueBtn.interactable = false;
        else ContinueBtn.interactable = true;

        SoundManager.instance.PlayBGM(BGMType.Title);
    }

    void OnClickStartBtn()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerHp", 3);
        PlayerPrefs.SetString("LastScene", firstSceneName);
        RoomManager.doorNumber = 0;

        SceneManager.LoadScene(firstSceneName);
    }

    void onClickContinueBtn()
    {
        string sceneName = PlayerPrefs.GetString("LastScene");
        RoomManager.doorNumber = PlayerPrefs.GetInt("LastDoor");

        SceneManager.LoadScene(sceneName);
    }
    
    void Update()
    {
        
    }
}
