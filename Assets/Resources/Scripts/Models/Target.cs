using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Models
{
    [Serializable]
    internal class Target
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private Text text;

        [SerializeField]
        private Image image;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Text Text
        {
            get { return text; }
            set { text = value; }
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
