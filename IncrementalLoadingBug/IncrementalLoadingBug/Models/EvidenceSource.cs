using IncrementalLoadingBug.ViewModels;
using Microsoft.Toolkit.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IncrementalLoadingBug.Models
{
    public class EvidencesSource : IIncrementalSource<EvidenceDTO>
    {
        public AppViewModel AppVM => App.AppVM;

        private readonly List<EvidenceDTO> evidences;

        public EvidencesSource()
        {
            evidences = new List<EvidenceDTO>();
            for (int i = 0; i < 200; i++)
            {
                evidences.Add(new EvidenceDTO() { NAME = "Name" + i.ToString() });
            }
        }

        public async Task<IEnumerable<EvidenceDTO>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            await Task.Delay(500); // fake web api call
            var result = (from dto in evidences
                          select dto).Skip(pageIndex * pageSize).Take(pageSize);
            return result;
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class PeopleSource : IIncrementalSource<Person>
    {
        private readonly List<Person> _people;

        public PeopleSource()
        {
            // Creates an example collection.
            _people = new List<Person>();

            for (int i = 1; i <= 200; i++)
            {
                var p = new Person { Name = "Person " + i };
                _people.Add(p);
            }
        }

        public async Task<IEnumerable<Person>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            // Gets items from the collection according to pageIndex and pageSize parameters.
            var result = (from p in _people
                          select p).Skip(pageIndex * pageSize).Take(pageSize);

            // Simulates a longer request...
            await Task.Delay(1000);

            return result;

        }
    }
}
