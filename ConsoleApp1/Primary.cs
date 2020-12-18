using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConsoleApp1
{
    public class Primary
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public Dependent DependentFirst { get; set; }
        public Dependent DependentSecond { get; set; }
        
        public Tertiary TertiaryFirst { get; set; }
        public Tertiary TertiarySecond { get; set; }
    }
}