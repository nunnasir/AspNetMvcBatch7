using System.Runtime.Intrinsics.Arm;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        ReportGenerate pdfReport = new ReportGenerate(new PDFReport());
        ReportGenerate excelReport = new ReportGenerate(new ExcelReport());


        //--Dependency Inversion Princtiple(DIP)
        var notify = new Notification(new SmsService());
        notify.Notify("");

        var notify2 = new Notification(new EmailService());
        notify.Notify("");
    }
}



/*
SOLID
-- Single Responsibility Principle
-- Open/Closed Principle (OCP)
-- Liskov Substitution Principle (LSP)
-- Interface Segregation Principle (ISP)
-- Dependency Inversion Princtiple (DIP)
 
 */


// Single Responsibility Principle
class Invoice
{
    public void CalculateTotal()
    {
        // Logic to calculate total
    }
}
class InvoiceRepository
{
    public void SaveToDatabase()
    {
        // Logic to save invoice to database
    }
}
class ReportGenerator
{
    public void GenerateReport(string type)
    {
        if (type == "PDF")
            Console.WriteLine("Generate PDF report");
        else if (type == "Excel")
            Console.WriteLine("Generate Excel report");
    }
}



// Open/Closed Principle (OCP)
public interface IReport
{
    void generate();
}

class PDFReport : IReport
{
    public void generate()
    {
        Console.WriteLine("Generate PDF report");
    }
}

class ExcelReport : IReport
{
    public void generate()
    {
        Console.WriteLine("Generate Excel report");
    }
}

public class  ReportGenerate
{
    public ReportGenerate(IReport report) => report.generate();
}

//Liskov Substitution Principle (LSP)
public abstract class  Bird
{
    public abstract void Move();
}

public class  Ostrich : Bird
{
    public override void Move()
    {
        Console.WriteLine("Running on Land");
    }
}

public class Eagle : Bird
{
    public override void Move()
    {
        Console.WriteLine("Flying on the sky");
    }
}


// Interface Segregation Principle (ISP)
interface IMachine
{
    void Print();
    void Scan();
    void Fax();
}

interface IPrinter
{
    void Print();
}

interface IScanner
{
    void Scan();
}

interface IFax
{
    void Fax();
}

public class SimplePrinter : IPrinter
{
    public void Print()
    {
        throw new NotImplementedException();
    }
}

public class MultuFunctionPrinter : IPrinter, IScanner, IFax
{
    public void Fax()
    {
        throw new NotImplementedException();
    }

    public void Print()
    {
        throw new NotImplementedException();
    }

    public void Scan()
    {
        throw new NotImplementedException();
    }
}


// Dependency Inversion Princtiple (DIP)
public class EmailServices
{
    public void SendEmail(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

public class SequenceServices
{
    public void CreateSequence(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

public class NotificationService
{
    private EmailServices email = new EmailServices();
    private SequenceServices sequence = new SequenceServices();

    public void Send(string message)
    {
        email.SendEmail(message);
    }
}

public interface IMessageService
{
    void Send(string message);
}

public class EmailService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}

public class SmsService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}

public class NotificationServices : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}

public class Notification
{
    private readonly IMessageService _messageService;
    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify(string message)
    {
        _messageService.Send(message);
    }
}




