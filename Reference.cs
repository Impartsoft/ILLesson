namespace ILLesson
{
    internal class Reference
    {
        public void SayHelloWorld()
        {
            Console.WriteLine("HelloWorld");
        }

        public string Replace(string value)
        {
            return value.Replace("\"", "\\\"");
        }
    }
}
