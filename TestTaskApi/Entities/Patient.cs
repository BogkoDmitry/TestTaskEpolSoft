using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TestTaskApi.Infrastructure.enums;

namespace TestTaskApi.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public PatientName Name { get; init; }
        public Gender Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }


        [Owned]
        public class PatientName
        {
            public string Use { get; set; }

            [Required]
            public string Family { get; set; }
            public string[] Given { get; set; }
        }
    }
}
