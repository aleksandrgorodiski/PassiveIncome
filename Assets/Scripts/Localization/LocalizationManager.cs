using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : GameElement
{
    public string english;
    public string ukrainian;

    private Dictionary<string, string> localizedText;
    private bool isReady;
    private string missingTextString = "Localized text not found";

    public void SelectLocalizationLanguage()
    {
        DontDestroyOnLoad(gameObject);

        if (app.gameSettings.ukrainianInAnyCase) LoadLocalizedText(ukrainian);
        else
        {
            if (Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Russian)
            {
                LoadLocalizedText(ukrainian);
            }
            else
            {
                LoadLocalizedText(english);
            }
        }
    }

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }
            Debug.Log("Localization Data loaded, dictionary contains: " + localizedText.Count + " entries");
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
        isReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        //Debug.Log("Key: " + key);

        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        //Debug.Log("String: " + result);
        return result;
    }

    public bool GetIsReady()
    {
        return isReady;
    }

}