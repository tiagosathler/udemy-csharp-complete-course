namespace S14C210.Entities;

internal abstract class Device
{
    public string SerialNumber { get; }

    protected Device(string serialNumber)
    {
        SerialNumber = serialNumber;
    }

    public abstract void ProcessDoc(string document);
}