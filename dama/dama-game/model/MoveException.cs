using System;
using System.Runtime.Serialization;

[Serializable]
internal class MoveException : Exception
{
    public MoveException()
    {
    }

    public MoveException(string message) : base(message)
    {
        throw new Exception(message);
    }

    public MoveException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected MoveException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}