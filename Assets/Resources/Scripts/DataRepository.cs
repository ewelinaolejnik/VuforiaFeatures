using Assets.Resources.Scripts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    internal class DataRepository
    {
        public Target GetTarget(string name)
        {
            try
            {
                
                string json = File.ReadAllText(Path.Combine(Paths.TargetDataPath, $"{name}.json"));
                return JsonUtility.FromJson<Target>(json);
            }
            catch(FileNotFoundException ex)
            {
                Debug.Log($"{Path.Combine(Paths.TargetDataPath, $"{name}.json")} not found");
                return null;
            }
        }

        public void SaveTarget(Target target)
        {
            string json = JsonUtility.ToJson(target);
            File.WriteAllText(Path.Combine(Paths.TargetDataPath,$"{target.Name}.json"), json);
        }
    }
}
