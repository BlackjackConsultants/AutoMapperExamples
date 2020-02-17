namespace AutoMapperExamples.Entity
{
    public class Phone : IEntity 
    {
        public int Id { get; set; }

        public string Number { get; set; }
    }
}