using Microsoft.EntityFrameworkCore;

namespace MasterData.Storage.DBInitialize
{
    public class DBInitializeHelper
    {
        public static void InsertInitialData(ModelBuilder modelBuilder)
        {
            DBInitializeUnitHelper.InsertInitialData(modelBuilder);
        }
    }
}