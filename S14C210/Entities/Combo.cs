namespace S14C210.Entities;

internal sealed class Combo : Device, IPrinter, IScanner
{
    public Combo(string serialNumber) : base(serialNumber)
    {
    }

    public override void ProcessDoc(string document)
    {
        Console.WriteLine($"Combo SN {SerialNumber} is processing {document}...");
    }

    public void Print(string document)
    {
        Console.WriteLine($"Combo SN {SerialNumber} is printing {document}...");
    }

    public string Scan()
    {
        return $"Combo SN {SerialNumber} scanned anything...";
    }
}