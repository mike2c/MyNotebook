using Core.Entities;
using System.Collections.Generic;

namespace Core.Domain.Topics
{
    public interface ITopicService
    {
        public IEnumerable<Topic> ListTopics();
    }
}
