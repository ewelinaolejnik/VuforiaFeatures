using Assets.Resources.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class VuforiaFeaturesController : MonoBehaviour
{
    [SerializeField]
    private Transform targetsContainer;

    private VuforiaService _vuforiaService;

    void Start()
    {
        _vuforiaService = new VuforiaService();
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
    }

    private void OnVuforiaStarted()
    {
        var dataSet = _vuforiaService.LoadDataSet(Paths.VuforiaDatabasePath);
        _vuforiaService.ActivateDataSet(dataSet);
        _vuforiaService.Targets.ForEach(target => target.SetParent(targetsContainer));
        _vuforiaService.Targets.ForEach(target => target.SetActive(true));
        _vuforiaService.Targets.ForEach(target => target.AddVirtualText("The blog you will love :)"));
    }
}
