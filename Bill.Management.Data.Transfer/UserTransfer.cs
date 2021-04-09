namespace Bill.Management.Data.Transfer
{
    public sealed record UserTransfer
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string SecondName { get; init; }

        public string ThirdName { get; init; }

        public string INN { get; set; }
    }
}
