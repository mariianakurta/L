using System;

class Gift
{
    private Sweets[] existance;

    public Gift(Sweets[] sweets)
    {
        existance = sweets;
    }

    public void GiftExistance()
    {
        Console.WriteLine("New Year's gift includes:");
        foreach (var sweets in existance)
        {
            Console.WriteLine($"{sweets.Name} ({sweets.GetType().Name}): Shape - {sweets.Shape}");
        }
    }

    public void CandiesShape()
    {
        Array.Sort(existance, (x, y) => string.Compare(x.Shape, y.Shape));
    }


    public Sweets CandiesLocation(string candyShape)
    {
        return Array.Find(existance, sweet => sweet.Shape == candyShape);
    }







}
