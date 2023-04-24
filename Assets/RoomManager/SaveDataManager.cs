using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataList arrangeDataList;
    void Start()
    {
        arrangeDataList = new SaveDataList();
        arrangeDataList.saveDatas = new List<SaveData>();
        //씬 이름 불러오기
        string stageName = PlayerPrefs.GetString("LastScene");
        //씬 이름을 키로 해 저장 데이터 읽어오기
        string data = PlayerPrefs.GetString(stageName);

        if (data != "") //기존 데이터가 존재하면
        {
            arrangeDataList = JsonUtility.FromJson<SaveDataList>(data);

            foreach (var saveData in arrangeDataList.saveDatas)
            {
                string objTag = saveData.objTag;
                GameObject[] objects = GameObject.FindGameObjectsWithTag(objTag);

                foreach (var obj in objects)
                {
                    switch (obj.tag)
                    {
                        case "Item":
                            ItemData itemData=obj.GetComponent<ItemData>(); 
                            if (itemData.arrangeId==saveData.arrangeId) Destroy(obj);
                            break;
                        case "ItemBox":
                            ItemBox box = obj.GetComponent<ItemBox>();
                            if (box.arrangeId == saveData.arrangeId)
                            {
                                box.isClosed=false;
                                obj.GetComponent<SpriteRenderer>().sprite = box.openImage;
                            }
                            break;
                        case "Door":
                            Door door= obj.GetComponent<Door>();
                            if (door.arrangeId == saveData.arrangeId) Destroy(obj);
                            break;
                        case "Enemy":
                            EnemyController enemy= obj.GetComponent<EnemyController>();
                            if(enemy.arrangeId == saveData.arrangeId) Destroy(obj);   
                            break;
                    }
                }
            }
        }
    }
    public static void SetArrangeId(int arrangeId, string objTag)
    {
        if (arrangeId == 0 || objTag == "") return;

        SaveData newData = new SaveData(arrangeId, objTag);
        arrangeDataList.saveDatas.Add(newData);

    }
    //save->씬 전환시 저장이 이루어진다.

    public static void SaveArrangeData(string stageName)
    {
        if (arrangeDataList.saveDatas != null && stageName != "")
        {
            string saveJson = JsonUtility.ToJson(arrangeDataList);
            PlayerPrefs.SetString(stageName, saveJson);
        }
    }

}
