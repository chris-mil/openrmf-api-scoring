using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace openstig_scoring_api.Models
{
    [Serializable]
    public class Artifact
    {
        public Artifact () {
            id= Guid.NewGuid();
            CHECKLIST = new CHECKLIST();
        }

        public DateTime created { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public CHECKLIST CHECKLIST { get; set; }
        public string rawChecklist { get; set; }
        
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId InternalId { get; set; }

        public Guid id { get; set; }
        public STIGtype type { get; set; }

        [BsonDateTimeOptions]
        // attribute to gain control on datetime serialization
        public DateTime? updatedOn { get; set; }

        public Guid createdBy { get; set; }
        public Guid? updatedBy { get; set; }
    }

    public enum STIGtype{
        ASD = 0,
        DBInstance = 10,
        DBServer = 20,
        DOTNET = 30,
        JAVA = 40
    }

}