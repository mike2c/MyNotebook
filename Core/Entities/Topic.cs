using System.Collections.Generic;

namespace Core.Entities
{
    public class Topic : Entity
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public virtual IEnumerable<Note> Notes { get; set; }

        public Topic() { }

        public Topic(int topicId, string topicName)
        {
            TopicId = topicId;
            TopicName = topicName;
        }
    }
}
