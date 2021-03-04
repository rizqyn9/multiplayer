using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using wahyu;

public class Data : MonoBehaviour
{
    public static void SaveProfile(profilData t_profile)

    {
        try
        {
            string path = Application.persistentDataPath + "/profile.dt";

            if (File.Exists(path)) File.Delete(path);

            FileStream file = File.Create(path);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, t_profile);
            file.Close();
        }
        catch
        {
            Debug.Log("something wrong");
        }
    }

    public static profilData LoadProfile()
    {
        profilData ret = new profilData();

        try
        {
            string path = Application.persistentDataPath + "/profile.dt";
            if (File.Exists(path))
            {
                FileStream file = File.Open(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                ret = (profilData)bf.Deserialize(file);
            }
        }
        catch
        {
            Debug.Log("something wrong load profile");
        }

        return ret;
    }
}