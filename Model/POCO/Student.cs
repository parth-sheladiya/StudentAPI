namespace StudentAPI.Model.POCO
{
    /// <summary>
    /// student poco model
    /// </summary>
    public class Student
    {
        /// <summary>
        /// student id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// student first name
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// student last name
        /// </summary>
        public string lastName { get; set; }

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
