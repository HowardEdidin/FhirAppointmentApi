using System.Configuration;

namespace ViewAppointments
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public static string EndPoint = ConfigurationManager.AppSettings["EndPoint"];

        /// <summary>
        /// 
        /// </summary>
        public static string AuthKey = ConfigurationManager.AppSettings["AuthKey"];

      
    

        public static string DatabaseId = ConfigurationManager.AppSettings["DatabaseId"];

        /// <summary>
        /// 
        /// </summary>
        public static string CollectionId = ConfigurationManager.AppSettings["CollectionId"];


    




    }
}