using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string _pathDest = "data.txt";
    public static void SaveData(ResourcesMananger resources, EmployeeMananger employee)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + _pathDest;
        FileStream stream = new FileStream(path, FileMode.Create);

        ResourcesData data = new ResourcesData(resources, employee);

        bf.Serialize(stream, data);
        stream.Close();
        Debug.Log("saved");
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
