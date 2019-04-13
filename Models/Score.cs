using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace openstig_scoring_api.Models
{
    /// <summary>
    /// This is the class that shows the score of the STIG for all categories
    /// </summary>

    public class Score
    {

        public Score () {        }

        #region members
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId InternalId { get; set; }        
        public ObjectId artifactId { get; set;}

        public string system { get; set; }
        public string hostName { get; set;}
        public string stigType { get; set; }
        public string stigRelease { get; set; }
        public string title { get {
            return hostName.Trim() + "-" + stigType.Trim() + "-" + stigRelease.Trim();
        }}
        
        [BsonDateTimeOptions]
        public DateTime created { get; set; }
        [BsonDateTimeOptions]
        // attribute to gain control on datetime serialization
        public DateTime? updatedOn { get; set; }
        public Guid createdBy { get; set; }
        public Guid? updatedBy { get; set; }


        public int totalCat1Open { get; set; }
        public int totalCat1NotApplicable { get; set; }
        public int totalCat1NotAFinding { get; set; }
        public int totalCat1NotReviewed { get; set; }
        public int totalCat2Open { get; set; }
        public int totalCat2NotApplicable{ get; set; }
        public int totalCat2NotAFinding { get; set; }
        public int totalCat2NotReviewed { get; set; }
        public int totalCat3Open { get; set; }
        public int totalCat3NotApplicable { get; set; }
        public int totalCat3NotAFinding { get; set; }
        public int totalCat3NotReviewed { get; set; }

        public int totalOpen { get { return totalCat1Open + totalCat2Open + totalCat3Open;} }
        public int totalNotApplicable { get { return totalCat1NotApplicable + totalCat2NotApplicable + totalCat3NotApplicable;} }
        public int totalNotAFinding { get { return totalCat1NotAFinding + totalCat2NotAFinding + totalCat3NotAFinding;} }
        public int totalNotReviewed { get { return totalCat1NotReviewed + totalCat2NotReviewed + totalCat3NotReviewed;} }

        public int totalCat1 { get { return totalCat1NotAFinding + totalCat1NotApplicable + totalCat1NotReviewed + totalCat1Open;} }
        public int totalCat2 { get { return totalCat2NotAFinding + totalCat2NotApplicable + totalCat2NotReviewed + totalCat2Open;} }
        public int totalCat3 { get { return totalCat3NotAFinding + totalCat2NotApplicable + totalCat3NotReviewed + totalCat3Open;} }
        #endregion

    }
}