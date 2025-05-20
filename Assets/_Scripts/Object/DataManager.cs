using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public DataBase data;

    [ContextMenu ("Save Data")]
    void SaveData()
    {
        var value = JsonUtility.ToJson (data);
        PlayerPrefs.SetString(nameof(data), value);
        PlayerPrefs.Save();
    }

    [ContextMenu("Load Data")]
    void LoadData()
    {
        var value = PlayerPrefs.GetString(nameof(data));
        data = JsonUtility.FromJson<DataBase>(value);
    }
}
