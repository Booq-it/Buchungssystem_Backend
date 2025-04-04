namespace Backend.Classes
{
    public abstract class Type(double price)
    {
        protected double m_Price { get;} = price;
    }

    public class Regular() : Type(10.9);
    
    public class Premium() : Type(15.9);
    
    public class Discount() : Type(8.9);
}