using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts
{
    internal class TargetActivateController
    {
        private Transform _mainPanel;
        private VuforiaService _vuforiaService;

        private static int _currentSimultaneousImageTargets;

        public TargetActivateController(Transform mainPanel, VuforiaService vuforiaService)
        {
            _currentSimultaneousImageTargets = 0;
            _mainPanel = mainPanel;
            _vuforiaService = vuforiaService;
        }

        public void CreateTargetButtons()
        {
            _vuforiaService.Targets.ForEach(target => SetButtonParent(CreateButton(target)));
        }

        private void SetButtonParent(Button button)
        {
            button.transform.SetParent(_mainPanel);
        }

        private Button CreateButton(ExtendedTrackableBehaviour target)
        {
            Button button = GameObject.Instantiate(UnityEngine.Resources.Load<Button>("Prefabs/Button"));
            button.gameObject.name = target.Name;
            var text = button.GetComponentInChildren<Text>();
            text.text = $"Activate {target.Name}";

            button.onClick.AddListener(() => OnTargetButtonClick(target, button));

            return button;
        }

        private void OnTargetButtonClick(ExtendedTrackableBehaviour target, Button currentButton)
        {
            var text = currentButton.GetComponentInChildren<Text>();

            if (target.IsActive && _currentSimultaneousImageTargets < _vuforiaService.MaxSimultaneousImageTargets)
            {
                target.SetActive(false);
                text.text = $"Activate {target.Name}";
                ++_currentSimultaneousImageTargets;
            }
            else
            {
                target.SetActive(true);
                text.text = $"Deactivate {target.Name}";
                --_currentSimultaneousImageTargets;
            }
        }
    }
}
