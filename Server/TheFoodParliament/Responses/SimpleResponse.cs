namespace TheFoodParliament.Responses
{
    public class SimpleResponse
    {
        public bool Status { get; private set; }
        public string Message { get; private set; }

        public static SimpleResponse Success(string message)
        {
            return new SimpleResponse { Status = true, Message = message };
        }

        public static SimpleResponse Error(string message)
        {
            return new SimpleResponse { Status = false, Message = message };
        }
    }
}