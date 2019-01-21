using System;
using UnityEngine;

namespace Assets.Resources.Scripts.Models
{
    [Serializable]
    internal class Image
    {
        [SerializeField]
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string Path => System.IO.Path.Combine(Paths.VirtualImagesPath, FileName);
    }
}
