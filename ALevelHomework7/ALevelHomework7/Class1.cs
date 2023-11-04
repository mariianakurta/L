class Candies : Sweets
{
    public string Flavor { get; set; }

    public Candies(string name, string shape, string flavor)
        : base(name, shape)
    {
        Flavor = flavor;
    }
}
