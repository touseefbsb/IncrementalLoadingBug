using Microsoft.Toolkit.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IncrementalLoadingBug.Models
{
    public class EvidencesSource : IIncrementalSource<EvidenceDTO>
    {
        private readonly List<EvidenceDTO> evidences;

        public EvidencesSource()
        {
            evidences = new List<EvidenceDTO>();
            for (int i = 0; i < 40; i++)
            {
                evidences.Add(new EvidenceDTO());
            }
        }

        public async Task<IEnumerable<EvidenceDTO>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {            
            await Task.Delay(500); // fake web api call
            return (from dto in evidences
                          select dto).Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}
