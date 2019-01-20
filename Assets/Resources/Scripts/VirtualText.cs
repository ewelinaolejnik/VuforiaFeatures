using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts
{
    internal class VirtualText
    {
        private GameObject _gameObject;
        private Text _text;

        public string Text
        {
            get { return _text.text; }
            set { _text.text = value; }
        }

        public VirtualText()
        {
            _gameObject = GameObject.Instantiate(UnityEngine.Resources.Load<GameObject>("Prefabs/Text"));
            _text = _gameObject.GetComponent<Text>();
        }

        public void SetParent(Transform parentTransform)
        {
            _gameObject.transform.SetParent(parentTransform);
        }
    }
}
