using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    internal static class Paths
    {
        public static string VuforiaPath
        {
            get
            {
                return Path.Combine(Application.persistentDataPath, "Vuforia");
            }
        }

        public static string VuforiaDatabasePath
        {
            get
            {
                var path = Path.Combine(VuforiaPath, "Database");
                return Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly).FirstOrDefault(f => f.Contains("ImageTargets"));
            }
        }
    }
}
