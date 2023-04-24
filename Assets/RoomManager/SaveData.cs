using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData //����� ���� �ڷ���
{
    public int arrangeId;
    public string objTag;
    

    public SaveData(int id, string tag) //������ �ʱⰪ
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
