namespace S14C210.Entities;

internal sealed class Printer : Device, IPrinter
{
    public Printer(string serialNumber) : base(serialNumber)
    {
    }

    public override void ProcessDoc(string document)
    {
        Console.WriteLine($"Printer SN {SerialNumber} is processing {document}...");
    }

    public void Print(string document)
    {
        Console.WriteLine($"Print SN {SerialNumber} is printing {document}...");
    }
}