namespace Selu383.SP25.Api.Dtos
{
    public class TheaterGetDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public int SeatCount { get; set; }
    }

    public class TheaterCreateDto
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public int SeatCount { get; set; }
    }

    public class TheaterUpdateDto
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public int SeatCount { get; set; }
    }
}

