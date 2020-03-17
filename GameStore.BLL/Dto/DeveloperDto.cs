using System;

namespace GameStore.BLL.Dto
{
    public class DeveloperDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string CompanyLogoUrl { get; set; }
    }
}
