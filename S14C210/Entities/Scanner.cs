namespace S14C210.Entities;

internal sealed class Scanner : Device, IScanner
{
    public Scanner(string serialNumber) : base(serialNumber)
    {
    }

    public override void ProcessDoc(string document)
    {
        Console.WriteLine($"Scanner SN {SerialNumber} is processing {document}...");
    }

    public string Scan()
    {
        return $"Scanner SN {SerialNumber} scanned anything...";
    }
}