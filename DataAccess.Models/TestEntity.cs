using System;
using DataAccess.Interfaces.Identifier;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
    public class TestEntity : IIdentifier
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public int TestPropertyInt { get; set; }

        public string TestPropertyString { get; set; }
    }
}