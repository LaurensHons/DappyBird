using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveInterface
{
        public static void SaveFile(GameData data)
        {
            string destination = Application.persistentDataPath + "saved.dat";
            FileStream file;
    
            if (File.Exists(destination)) file = File.OpenWrite(destination);
            else file = File.Create(destination);
            
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
            file.Close();
        }
        
        public static GameData LoadFile()
        {
            string destination = Application.persistentDataPath + "saved.dat";
            FileStream file;
     
            if(File.Exists(destination)) file = File.OpenRead(destination);
            else
            {
                Debug.LogError("File not found");
                return new GameData();
            }
     
            BinaryFormatter bf = new BinaryFormatter();
            GameData data = (GameData) bf.Deserialize(file);
            file.Close();

            return data;
        }
}
