using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts
{
    internal class TrackableEventHandler : DefaultTrackableEventHandler
    {
        protected override void OnTrackingFound()
        {
            base.OnTrackingFound();
            SetComponentsBehaviour(true);
        }

        protected override void OnTrackingLost()
        {
            base.OnTrackingLost();
            SetComponentsBehaviour(false);
        }

        private void SetComponentsBehaviour(bool value)
        {
            var textComponents = GetComponentsInChildren<Text>(true);
            var imageComponents = GetComponentsInChildren<RawImage>(true);

            foreach (var component in textComponents)
                component.enabled = value;

            foreach (var component in imageComponents)
                component.enabled = value;
        }
    }
}
