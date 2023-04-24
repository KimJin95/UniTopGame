using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData //사용자 정의 자료형
{
    public int arrangeId;
    public string objTag;
    

    public SaveData(int id, string tag) //생성자 초기값
    {
        arrangeId = id;
        objTag = tag;
    }
}

[System.Serializable]
public class SaveDataList
{
    public List<SaveData> saveDatas=new List<SaveData>();
}
