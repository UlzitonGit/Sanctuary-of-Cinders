using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    private static string _pathDest = "data.txt";

    public static void SaveData(ResourcesMananger resources, EmployeeMananger employee, UpgradeMananger upgradeMananger)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + _pathDest;
        FileStream stream = new FileStream(path, FileMode.Create);

        ResourcesData data = new ResourcesData(resources, employee, upgradeMananger);

        bf.Serialize(stream, data);
        stream.Close();
        Debug.Log("saved");
    }
    private static string SaveFilePath
    {
        get { return Application.persistentDataPath + _pathDest; }
    }
    public static bool HasFile()
    {
        string path = Application.persistentDataPath + _pathDest;
        return File.Exists(path);
    }

    public static void Delete()
    {
        try
        {
            File.Delete(SaveFilePath);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    public static ResourcesData LoadResoures()
    {
        string path = Application.persistentDataPath + _pathDest;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ResourcesData resources = bf.Deserialize(stream) as ResourcesData;
            stream.Close();
            Debug.Log(path);
            return resources;
        }
        else
        {
            Debug.Log("cant find saved data");
            return null;
        }
    }
}
