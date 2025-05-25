using Newtonsoft.Json;

namespace StudentAPI.Model.DTO
{
    /// <summary>
    /// student dto model
    /// </summary>
    public class StudentDTO
    {
        /// <summary>
        /// student id
        /// </summary>
        [JsonIgnore]
        public int id { get; set; }

        /// <summary>
        /// student fullname
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// student class
        /// </summary>
        public int Class { get; set; }

        /// <summary>
        /// student marks
        /// </summary>
        public int Marks { get; set; }

    }
}
