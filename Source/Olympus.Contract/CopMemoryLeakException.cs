using System;

namespace nGratis.Cop.Olympus.Contract;

using System.Runtime.Serialization;

[Serializable]
public class CopMemoryLeakException : CopException
{
    public CopMemoryLeakException()
    {
    }

    public CopMemoryLeakException(string message)
        : base(message)
    {
    }

    public CopMemoryLeakException(string message, Exception exception)
        : base(message, exception)
    {
    }

    protected CopMemoryLeakException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}