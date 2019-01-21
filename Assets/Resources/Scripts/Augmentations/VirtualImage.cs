using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Augmentations
{
    internal class VirtualImage : VirtualObject
    {
        private RawImage _image;

        public Texture2D Image
        {
            get { return _image.texture as Texture2D; }
            set { _image.texture = value; }
        }

        public VirtualImage()
        {
            _gameObject = GameObject.Instantiate(UnityEngine.Resources.Load<GameObject>("Prefabs/Image"));
            _image = _gameObject.GetComponent<RawImage>();
        }
    }
}
