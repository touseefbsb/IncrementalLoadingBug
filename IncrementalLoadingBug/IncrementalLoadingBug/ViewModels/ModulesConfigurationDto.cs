using IncrementalLoadingBug.Helpers;
using Newtonsoft.Json;
using System;

namespace IncrementalLoadingBug.ViewModels
{
    public class ModulesConfigurationDto : Observable
    {
        private int _queryCount;

        public string ModuleCode { get; set; }
        public string DisplayName { get; set; }


        public int QueryCount { get => _queryCount; set => Set(ref _queryCount, value); }

        #region JsonIgnore

        [JsonIgnore]
        public object Evidences { get; set; }

        #endregion
    }
}