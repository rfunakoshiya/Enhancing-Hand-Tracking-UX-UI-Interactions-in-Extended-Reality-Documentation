using System.IO;
using DataClasses;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    private string _persistentDataPath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void Start()
    {
        _persistentDataPath = Application.persistentDataPath;
    }

    public void SaveData(InteractionData interactionData)
    {
        string safeTimeForSaving = interactionData.startTime.Replace(":", "-").Replace(" ", "_");
        string fileName = $"interactionData_{safeTimeForSaving}.json";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(filePath, JsonConvert.SerializeObject(interactionData,Formatting.Indented));
        Debug.Log("Saved InteractionData to " + filePath);
    }
}
