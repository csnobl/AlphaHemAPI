namespace AlphaHemAPI.Data.Models
{
    //Author : ALL
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Presentation { get; set; }
        public string Logo { get; set; }

        //Navigation properties

        public List<Realtor> Realtors { get; set; }

    }
}
