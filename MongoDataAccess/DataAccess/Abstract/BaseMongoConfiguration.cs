
namespace MongoDataAccess.DataAccess.Abstract
{
    public abstract class BaseMongoConfiguration
    {
        //Conenction String
        public const string ConnectionString = "mongodb://localhost:27017";

        //Database name
        public const string DatabaseName = "choredb";

        //Collection names
        public const string ChoreCollection = "chore_chart";
        public const string UserCollection = "users";
        public const string ChoreHistoryCollection = "chore_history";
    }
}
