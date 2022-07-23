using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace FlyMan.Old
{
    public class StorageDataGame : MonoBehaviour
    {
        private int _topScore;

        private void Awake()
        {
            LoadData();
        }
        private void SaveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
              + "/MySaveData.dat");
            SaveData data = new SaveData();
            data.TopScore = _topScore;
            bf.Serialize(file, data);
            file.Close();
        }

        private void LoadData()
        {
            if (File.Exists(Application.persistentDataPath
              + "/MySaveData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file =
                  File.Open(Application.persistentDataPath
                  + "/MySaveData.dat", FileMode.Open);
                SaveData data = (SaveData)bf.Deserialize(file);
                file.Close();
                _topScore = data.TopScore;
            }
            else Debug.LogError("There is no save data!");
        }

        public int GetTopScore()
        {
            return _topScore;
        }

        public void SetTopScore(int topScore)
        {
            _topScore = topScore;
            SaveData();
        }
    }
    [Serializable]
    class SaveData
    {
        public int TopScore;
    }
}
