using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class ChoreModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ChoreText { get; set; }
        public int FrequencyInDays { get; set; }
        public UserModel? AssignedTo { get; set; }
        public DateTime? LastCompleted { get; set; }
    }
}
