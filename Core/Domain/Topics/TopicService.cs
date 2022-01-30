using Core.Entities;
using Core.Repository;
using System.Collections.Generic;

namespace Core.Domain.Topics
{
    public class TopicService : ITopicService
    {
        private ITopicRepository topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            this.topicRepository = topicRepository;
        }

        public IEnumerable<Topic> ListTopics()
        {
            var topics = this.topicRepository.List();
            return topics;
        }
    }
}
