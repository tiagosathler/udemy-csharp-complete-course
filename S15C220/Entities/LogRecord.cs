namespace S15C220.Entities;

internal class LogRecord : IComparable
{
    public string? UserName { get; set; }

    public DateTime Instant { get; set; }

    public LogRecord()
    { }

    public LogRecord(string userName, DateTime instant)
    {
        UserName = userName;
        Instant = instant;
    }

    public override sealed int GetHashCode()
    {
        return UserName?.GetHashCode() ?? 0;
    }

    public override sealed bool Equals(object? obj)
    {
        return obj is LogRecord logRecord && logRecord.UserName?.Equals(UserName) == true;
    }

    public int CompareTo(object? obj)
    {
        if (obj is not LogRecord)
        {
            throw new ArgumentException("I can't compare different objects");
        }
        LogRecord other = (LogRecord)obj;
        return UserName?.CompareTo(other.UserName) ?? -1;
    }

    public override sealed string ToString()
    {
        return $"User: {UserName} - Accessed instant: {Instant}";
    }

    // https://rules.sonarsource.com/csharp/RSPEC-1210/

    public static bool operator ==(LogRecord? left, LogRecord? right)
    {
        if (left is null || right is null)
        {
            return left is null && right is null;
        }
        return left.Equals(right);
    }

    public static bool operator !=(LogRecord? left, LogRecord? right)
    {
        return !(left == right);
    }

    private static bool IsNotItNull(LogRecord? left, LogRecord? right)
    {
        return left is not null
            && right is not null
            && left.UserName is not null
            && right.UserName is not null;
    }

    public static bool operator >(LogRecord? left, LogRecord? right)
    {
        if (IsNotItNull(left, right))
        {
            return left!.CompareTo(right) > 0;
        }
        return false;
    }

    public static bool operator >=(LogRecord? left, LogRecord? right)
    {
        if (IsNotItNull(left, right))
        {
            return left!.CompareTo(right) >= 0;
        }
        return false;
    }

    public static bool operator <(LogRecord? left, LogRecord? right)
    {
        if (IsNotItNull(left, right))
        {
            return left!.CompareTo(right) < 0;
        }
        return false;
    }

    public static bool operator <=(LogRecord? left, LogRecord? right)
    {
        if (IsNotItNull(left, right))
        {
            return left!.CompareTo(right) <= 0;
        }
        return false;
    }
}