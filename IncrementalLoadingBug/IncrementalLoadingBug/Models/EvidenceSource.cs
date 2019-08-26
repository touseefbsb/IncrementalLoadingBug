using IncrementalLoadingBug.ViewModels;
using Microsoft.Toolkit.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IncrementalLoadingBug.Models
{
    public class EvidencesSource : IIncrementalSource<EvidenceDTO>
    {
        public AppViewModel AppVM => App.AppVM;

        public async Task<IEnumerable<EvidenceDTO>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var evidences = new List<EvidenceDTO>();
            await Task.Delay(500); // fake web api call
            evidences.Add(new EvidenceDTO { Agency = "abc", AudioCount = 0, BarCodeNumber = "123" });
            return evidences;
        }
    }
}
