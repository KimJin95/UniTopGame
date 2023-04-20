using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public string retrySceneName;
    [SerializeField] Text arrowText;
    [SerializeField] Text keyText;

    [SerializeField] Image lifeImage;
    [SerializeField] Sprite[] lifes;

    [SerializeField] Image mainImage;
    [SerializeField] Sprite gameoverSprite;
    [SerializeField] Sprite gameClearSprite;

    [SerializeField] GameObject retryBtn;
    [SerializeField] GameObject inputPanel;

    int hasArrow, hasKey, hp;



    void Start()
    {
      
        retryBtn.SetActive(false);
        inputPanel.SetActive(false);
        Invoke("InactiveImage", 1);

        UpdateItemUI();
        UpdateHp();

    }
    void InactiveImage()
    {
        mainImage.gameObject.SetActive(false);
        inputPanel.SetActive(true);
     
    }


    void Update()
    {
        UpdateItemUI();
        UpdateHp();
    }

    void UpdateItemUI()
    {
        if (hasArrow != ItemKeeper.hasArrows)
        {
            hasArrow = ItemKeeper.hasArrows;
            arrowText.text = hasArrow.ToString("00");

        }
        if (hasKey != ItemKeeper.hasKeys)
        {
            hasKey = ItemKeeper.hasKeys;
            keyText.text = hasKey.ToString("00");

        }

    }
    void UpdateHp()
    {
        
        if (hp != PlayerMove.hp)
        {
            hp = PlayerMove.hp;
            lifeImage.sprite = lifes[hp];

            if (hp <= 0)
            {
                print("1");

                retryBtn.SetActive(true);
                mainImage.sprite = gameoverSprite;
                mainImage.gameObject.SetActive(true);
                inputPanel.SetActive(false);

            }
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(retrySceneName);
    }
}
