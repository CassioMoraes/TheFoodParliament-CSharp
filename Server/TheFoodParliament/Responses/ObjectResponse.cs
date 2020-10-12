namespace TheFoodParliament.Responses
{
    public class ObjectResponse
    {
        public bool Status { get; private set; }
        public string Message { get; private set; }
        public object Result { get; set; }

        public static ObjectResponse Success(string message, object result)
        {
            return new ObjectResponse { Status = true, Message = message, Result = result };
        }

        public static ObjectResponse Error(string message, object result)
        {
            return new ObjectResponse { Status = false, Message = message, Result = result };
        }
    }
}