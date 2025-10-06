using Microsoft.EntityFrameworkCore;

namespace TestingPlatform.Models
{

    [Index(nameof(Name), IsUnique = true)]
    public class Direction
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        //навигация
        
        public List<Group> Groups { get; set; }

        public List<Test> Tests { get; set; }
    }
}

