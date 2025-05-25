using StudentAPI.Model.DTO;
using StudentAPI.Model.POCO;

namespace StudentAPI.Extension
{
    /// <summary>
    /// dto to poco class
    /// </summary>
    public static class Convert
    {
        /// <summary>
        /// extension method
        /// </summary>
        /// <param name="dto">dto obj</param>
        /// <returns>poco model</returns>
        public static Student ToPoco(this StudentDTO dto)
        {
            // split full name 
            string[] names = dto.Fullname?.Trim().Split(' ') ?? new string[2];

            // 0 index is first name and 1 index is last name
            string firstName = names.Length > 0 ? names[0] : "";
            string lastName = names.Length > 1 ? names[1] : "";

            // return new poco
            return new Student
            {
                id = dto.id,
                firstName = firstName,
                lastName = lastName,
                Class = dto.Class,
                Marks = dto.Marks
            };
        }

    }
}
