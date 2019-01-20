using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Vuforia;

namespace Assets.Resources.Scripts
{
    internal sealed class ExtendedTrackableBehaviour
    {
        private TrackableBehaviour _target;

        public ExtendedTrackableBehaviour(TrackableBehaviour target)
        {
            _target = target;
            _target.gameObject.name = _target.TrackableName;
            _target.gameObject.AddComponent<TrackableEventHandler>();
        }

        public void AddVirtualText(string text)
        {
            var virtualText = new VirtualText
            {
                Text = text
            };

            virtualText.SetParent(_target.transform);
        }

        public void SetParent(Transform parentTransform)
        {
            _target.transform.SetParent(parentTransform);
        }

        public void SetActive(bool value)
        {
            _target.gameObject.SetActive(value);
        }
    }
}
