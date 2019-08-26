using IncrementalLoadingBug.Helpers;
using Newtonsoft.Json;
using System;

namespace IncrementalLoadingBug.ViewModels
{
    public class ModulesConfigurationDto : Observable
    {
        private int _queryCount;

        public Guid Id { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public string DisplayName { get; set; }

        public string FilterType
        {
            get => _filterType; set => Set(ref _filterType, value);
        }

        public int QueryCount { get => _queryCount; set => Set(ref _queryCount, value); }
        public string APIEndPoint { get; set; }
        public string APIQueryString { get; set; }
        public string QueryTables { get; set; }
        public string ReturnType { get; set; }
        public bool IsActive { get; set; }


        #region JsonIgnore
        private bool _isLoading;

        private string _filterType;

        [JsonIgnore]
        public object Evidences { get; set; }

        [JsonIgnore]
        public bool IsLoading { get => _isLoading; set => Set(ref _isLoading, value); }

        #endregion
    }
}