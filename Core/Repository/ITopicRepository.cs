using Core.Entities;
using System.Collections.Generic;

namespace Core.Repository
{
    public interface ITopicRepository : IRepository<Topic>
    {
        public IEnumerable<Topic> List();        
    }
}
