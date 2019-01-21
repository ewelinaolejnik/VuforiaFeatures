using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Augmentations
{
    internal abstract class VirtualObject
    {
        protected GameObject _gameObject;

        public void SetParent(Transform parentTransform)
        {
            _gameObject.transform.SetParent(parentTransform);
        }
    }
}
