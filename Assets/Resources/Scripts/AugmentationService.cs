using Assets.Resources.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resources.Scripts
{
    internal class AugmentationService
    {
        private DataRepository _repository;
        private VuforiaService _vuforiaService;

        public AugmentationService(DataRepository repository, VuforiaService vuforiaService)
        {
            _repository = repository;
            _vuforiaService = vuforiaService;
        }
       
        public List<Target> CreateAugmentations()
        {
            List<Target> targets = new List<Target>();
            foreach (var imageTarget in _vuforiaService.Targets)
            {
                var targetModel = _repository.GetTarget(imageTarget.Name);
                if (targetModel == null)
                {
                    targetModel = new Target()
                    {
                        Name = imageTarget.Name,
                        Image = new Image()
                        {
                            FileName = "DefaultImage.png"
                        },
                        Text = new Text()
                        {
                            Content = "The blog you will love :)"
                        }
                    };

                    _repository.SaveTarget(targetModel);
                }

                targets.Add(targetModel);
            }

            return targets;
        }
    }
}
