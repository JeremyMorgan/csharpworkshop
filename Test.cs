
namespace csharplearning
{
    class Test
    {
        public string ourMessage;

        public test()
        {
            ourMessage = "Empty - no parameters";
        }

        public test(int ourInt)
        {
            ourMessage = "An integer was passed";
        }

        public test(string ourstring)
        {
            ourMessage = "A string was passed";
        }

        public test(string ourstring, int ourInt)
        {
            ourMessage = "Both a string and integer were passed";
        }
    }
}
