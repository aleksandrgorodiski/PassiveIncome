using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public sealed class ConfigController : Singleton<ConfigController>
{
    private const string kConfigResourceName = "config";
    private const string kConfigFileName = kConfigResourceName + ".txt";

    public GlobalConfigs Info { get; private set; }

    private string PersistPath
    {
        get { return Path.Combine(Application.persistentDataPath, kConfigFileName); }
    }

    public void SaveToResources()
    {
        Info = new GlobalConfigs();
        Info.Name = "Test";
        Info.Speed = 3;

        var data = JsonConvert.SerializeObject(Info);
        var path = Path.Combine(Path.Combine(Application.dataPath, "Resources"), kConfigFileName);
        File.WriteAllText(path, data);
    }

    public void SaveToPersistent()
    {
        var data = JsonConvert.SerializeObject(Info);
        File.WriteAllText(PersistPath, data);
    }

    public GlobalConfigs LoadFromResources()
    {
        Info = JsonConvert.DeserializeObject<GlobalConfigs>(Resources.Load<TextAsset>(kConfigResourceName).text);
        return Info;
    }

    public GlobalConfigs LoadFromPersistent()
    {
        Info = JsonConvert.DeserializeObject<GlobalConfigs>(File.ReadAllText(PersistPath));
        return Info;
    }

    protected override void OnReleaseResources()
    {
    }
}