using Models = Assets.Resources.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Vuforia;
using Assets.Resources.Scripts.Augmentations;
using System.IO;

namespace Assets.Resources.Scripts
{
    internal sealed class ExtendedTrackableBehaviour
    {
        private TrackableBehaviour _target;

        public bool IsActive => _target.gameObject.activeSelf;
        public string Name => _target.TrackableName;

        public ExtendedTrackableBehaviour(TrackableBehaviour target)
        {
            _target = target;
            _target.gameObject.name = _target.TrackableName;
            _target.gameObject.AddComponent<TrackableEventHandler>();

            SetActive(false);
        }

        public void AddVirtualText(Models.Text text)
        {
            var virtualText = new VirtualText
            {
                Text = text.Content,
                Color = text.Color
            };

            virtualText.SetParent(_target.transform);
        }

        public void AddVirtualImage(Models.Image image)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(File.ReadAllBytes(image.Path));

            var virtualImage = new VirtualImage
            {
                Image = texture
            };

            virtualImage.SetParent(_target.transform);
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
