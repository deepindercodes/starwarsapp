using System.Net;

namespace starwarsapp.Models
{
    /// <summary>
    /// This class will define the various utility methods, to be used repeatedly.
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// This method will be used to make api call, and get the json response from the api
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string GetWebResponse(string uri)
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(uri);
            }
        }
    }
}