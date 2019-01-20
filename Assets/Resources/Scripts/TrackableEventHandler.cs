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

            var textComponents = GetComponentsInChildren<Text>(true);
            SetComponentsBehaviour(textComponents, true);
        }

        protected override void OnTrackingLost()
        {
            base.OnTrackingLost();

            var textComponents = GetComponentsInChildren<Text>(true);
            SetComponentsBehaviour(textComponents, false);
        }

        private void SetComponentsBehaviour(Behaviour[] components, bool value)
        {
            foreach (var component in components)
                component.enabled = value;

        }
    }
}
