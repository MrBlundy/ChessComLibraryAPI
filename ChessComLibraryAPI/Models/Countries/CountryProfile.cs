using Newtonsoft.Json;

namespace ChessComLibraryAPI.Models.Countries
{
    /// <summary>
    /// Get additional details about a country
    /// </summary>
    public class CountryProfile
    {
        /// <summary>
        /// The location of this profile (always self-referencing)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The human-readable name of this country
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ISO-3166-1 2-character code
        /// </summary>
        public string Code { get; set; }
    }
}
