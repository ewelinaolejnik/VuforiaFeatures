using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Models
{
    [Serializable]
    internal class Text
    {
        [SerializeField]
        private string content;

        [SerializeField]
        private string color;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private Color _color;
        public Color Color
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(color, out _color))
                {
                    return _color;
                }

                return Color.white;
            }
        }
    }
}
