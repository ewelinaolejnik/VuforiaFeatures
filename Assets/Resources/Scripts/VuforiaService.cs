using Vuforia;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Assets.Resources.Scripts
{
    internal class VuforiaService
    {
        private ObjectTracker _objectTracker;
        public ObjectTracker ObjectTracker
        {
            get
            {
                if(_objectTracker == null)
                {
                    _objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                }

                return _objectTracker;
            }
        }

        public List<ExtendedTrackableBehaviour> Targets { get; private set; }

        public VuforiaService()
        {
            Targets = new List<ExtendedTrackableBehaviour>();
        }
        

        /// <summary>
        /// Loads data set and set targets from the data set. 
        /// </summary>
        public DataSet LoadDataSet(string databaseAbsolutePath)
        {
            try
            {

                if (string.IsNullOrEmpty(databaseAbsolutePath))
                {
                    throw new ArgumentException($"Vuforia database path cannot be null or empty.");
                }
                
                if (!DataSet.Exists(databaseAbsolutePath, VuforiaUnity.StorageType.STORAGE_ABSOLUTE))
                {
                    throw new ArgumentException($"Data set {Paths.VuforiaDatabasePath} does not exist.");
                }
               
                DataSet dataSet = ObjectTracker.CreateDataSet();
               
                if (!dataSet.Load(databaseAbsolutePath, VuforiaUnity.StorageType.STORAGE_ABSOLUTE))
                {
                    throw new ArgumentException($"Failed to load data set {Paths.VuforiaDatabasePath}.");
                }

                Targets = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours().Select(target => new ExtendedTrackableBehaviour(target)).ToList();

                return dataSet;
            }
            catch(ArgumentException ex)
            {
                Debug.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Activates passed data set.
        /// </summary>
        /// <param name="dataSet"></param>
        public void ActivateDataSet(DataSet dataSet)
        {
            ObjectTracker.Stop();
            ObjectTracker.ActivateDataSet(dataSet);
            ObjectTracker.Start();
        }
    }
}
