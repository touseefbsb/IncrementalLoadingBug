using IncrementalLoadingBug.Helpers;
using IncrementalLoadingBug.Models;
using Microsoft.Toolkit.Uwp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace IncrementalLoadingBug.ViewModels
{
    public class AppViewModel : Observable
    {
        private ModulesConfigurationDto _topListViewItem;
        private ObservableCollection<ModulesConfigurationDto> _evidencesConfigurationList;

        public ModulesConfigurationDto TopListViewItem { get => _topListViewItem; set => Set(ref _topListViewItem, value); }

        public ObservableCollection<ModulesConfigurationDto> EvidencesConfigurationList { get { if (_evidencesConfigurationList is null) { _evidencesConfigurationList = new ObservableCollection<ModulesConfigurationDto>(); } return _evidencesConfigurationList; } set => Set(ref _evidencesConfigurationList, value); }


        public async Task LoadDataAsync()
        {
            await LoadModulesConfiguration();
        }

        public async Task LoadModulesConfiguration()
        {
            await Task.Delay(200);//fake web api call

            List<ModulesConfigurationDto> result = new List<ModulesConfigurationDto> {
                new ModulesConfigurationDto { DisplayName = "RecentEvidences", ModuleCode = "TM", QueryCount = 27 },
                new ModulesConfigurationDto { DisplayName = "Evidences", ModuleCode = "TM", QueryCount = 27 }};

            if (result?.Count > 0)
            {
                EvidencesConfigurationList.Clear();

                IEnumerable<ModulesConfigurationDto> evidencesConfigurationList = result.Where(a => a.ModuleCode == "TM");

                foreach (ModulesConfigurationDto item in evidencesConfigurationList)
                {
                    item.Evidences = new IncrementalLoadingCollection<EvidencesSource, EvidenceDTO>(itemsPerPage: 0);
                }
                EvidencesConfigurationList.AddRange(evidencesConfigurationList);
            }
        }
    }
}
