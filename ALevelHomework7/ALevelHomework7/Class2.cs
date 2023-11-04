class Cookies : Sweets
{
    public string Type { get; set; }

    public Cookies(string name, string shape, string type)
        : base(name, shape)
    {
        Type = type;
    }
}
