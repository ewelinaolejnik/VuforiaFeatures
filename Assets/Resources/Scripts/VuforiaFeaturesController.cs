using Assets.Resources.Scripts;
using System.Collections;
using System.Collections.Generic;
using Models = Assets.Resources.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class VuforiaFeaturesController : MonoBehaviour
{
    [SerializeField]
    private Transform targetsContainer;

    [SerializeField]
    private Transform mainPanel;

    private AugmentationService _augmentationService;
    private VuforiaService _vuforiaService;
    private TargetActivateController _targetActivateView;
    private DataRepository _repostory;
     

    void Start()
    {
        _vuforiaService = new VuforiaService();
        _repostory = new DataRepository();
        _targetActivateView = new TargetActivateController(mainPanel, _vuforiaService);
        _augmentationService = new AugmentationService(_repostory, _vuforiaService);
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
    }

    private void OnVuforiaStarted()
    {
        var dataSet = _vuforiaService.LoadDataSet(Paths.VuforiaDatabasePath);
        _vuforiaService.ActivateDataSet(dataSet);
        _vuforiaService.Targets.ForEach(target => target.SetParent(targetsContainer));
        _targetActivateView.CreateTargetButtons();
        List<Models.Target> targets = _augmentationService.CreateAugmentations();
        _vuforiaService.Targets.ForEach(target => 
        {
            var targetModel = targets.Find(t => t.Name == target.Name);
            target.AddVirtualText(targetModel.Text);
            target.AddVirtualImage(targetModel.Image);
        });
    }
    
}
