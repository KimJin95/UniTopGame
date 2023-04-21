using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Button StartBtn;
    [SerializeField] Button ContinueBtn;

    
    void Start()
    {
        StartBtn.onClick.AddListener(() => { OnClickStartBtn(); });
        ContinueBtn.onClick.AddListener(() => { OnContinueBtn(); });
    }

    void OnClickStartBtn()
    {
       
    }

    void OnContinueBtn()
    {
        
    }
    
    void Update()
    {
        
    }
}
