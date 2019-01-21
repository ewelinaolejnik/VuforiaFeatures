using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Augmentations
{
    internal class VirtualText : VirtualObject
    {
        private Text _text;

        public string Text
        {
            get { return _text.text; }
            set { _text.text = value; }
        }

        public Color Color
        {
            get { return _text.color; }
            set { _text.color = value; }
        }

        public VirtualText()
        {
            _gameObject = GameObject.Instantiate(UnityEngine.Resources.Load<GameObject>("Prefabs/Text"));
            _text = _gameObject.GetComponent<Text>();
        }
    }
}
