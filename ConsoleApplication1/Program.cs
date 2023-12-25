namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var p = new Person("John", "Doe");
            System.Console.WriteLine(p);
        }
    }

    internal struct Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Person(string john, string doe)
        {
            FirstName = john;
            LastName = doe;
        }
        
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}