﻿using System;


public class Computer
{

    private string _type;
    public string Motherboard { get; set; }
    public string Processor { get; set; }
    public string Disk { get; set; }
    public double Price { get; set; }
    public string Screen { get; set; }

    public Computer(string computerType)
    {
        _type = computerType;
        Price = 0;
    }

    public void DisplayConfiguration()
    {
        Console.WriteLine("Typ: " + _type);
        Console.WriteLine("Płyta główna: " + Motherboard);
        Console.WriteLine("Procesor: " + Processor);
        Console.WriteLine("Dysk: " + Disk);
        Console.WriteLine("Monitor: " + Screen);
        Console.WriteLine("Cena: " + Price + " zl");
    }
}


public class ComputerShop
{

    public void ConstructComputer(ComputerBuilder computerBuilder)
    {
        computerBuilder.BuildMotherboard();
        computerBuilder.BuildProcessor();
        computerBuilder.BuildDisk();
        computerBuilder.BuildScreen();
    }

}



public abstract class ComputerBuilder
{

    public Computer Computer { get; set; }
    public abstract void BuildMotherboard();
    public abstract void BuildProcessor();
    public abstract void BuildDisk();
    public abstract void BuildScreen();

}


public class OfficeComputerBuilder : ComputerBuilder
{

    public OfficeComputerBuilder()
    {
        Computer = new Computer("biurowy");
    }
    public override void BuildMotherboard()
    {
        Computer.Motherboard = "Asus Prime A320M-E";
        Computer.Price += 259.90;
    }

    public override void BuildProcessor()
    {
        Computer.Processor = "AMD Ryzen 5 2600";
        Computer.Price += 589.00;
    }

    public override void BuildDisk()
    {
        Computer.Disk = "Goodram CX400 250 GB SATA3";
        Computer.Price += 149.99;
    }

    public override void BuildScreen()
    {
        Computer.Screen = "BenQ GW2270H (1920x1080)";
        Computer.Price += 369.00;
    }

}

public class GameComputerBuilder : ComputerBuilder
{
    public GameComputerBuilder()
    {
        Computer = new Computer("dla graczy");
    }
    public override void BuildMotherboard()
    {
        Computer.Motherboard = "Gigabyte X570 Aorus Elite";
        Computer.Price += 895.60;
    }

    public override void BuildProcessor()
    {
        Computer.Processor = "Intel i7 9700K";
        Computer.Price += 1829.00;
    }

    public override void BuildDisk()
    {
        Computer.Disk = "Samsung 970 EVO Plus 2TB M.2";
        Computer.Price += 2028.45;
    }

    public override void BuildScreen()
    {
        Computer.Screen = "HP Z4W65A4 (3840x1600)";
        Computer.Price += 4927.75;
    }
}

public class ProfessionalsComputerBuilder : ComputerBuilder
{
    public ProfessionalsComputerBuilder()
    {
        Computer = new Computer("dla profesjonalistów");
    }
    public override void BuildMotherboard()
    {
        Computer.Motherboard = "Supermicro MBD X11DPH";
        Computer.Price += 2755.30;
    }

    public override void BuildProcessor()
    {
        Computer.Processor = "Intel Xeon Gold 5120";
        Computer.Price += 7999.00;
    }

    public override void BuildDisk()
    {
        Computer.Disk = "Seagate Skyhawk 14TB 3.5";
        Computer.Price += 2101.75;
    }

    public override void BuildScreen()
    {
        Computer.Screen = "Eizo CG319X";
        Computer.Price += 20749.00;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        ComputerShop computerShop = new ComputerShop();

        ComputerBuilder computerBuilder = new OfficeComputerBuilder();
        computerShop.ConstructComputer(computerBuilder);
        computerBuilder.Computer.DisplayConfiguration();

        Console.WriteLine();

        ComputerBuilder game = new GameComputerBuilder();
        computerShop.ConstructComputer(game);
        game.Computer.DisplayConfiguration();

        Console.WriteLine();

        ComputerBuilder professionals = new ProfessionalsComputerBuilder();
        computerShop.ConstructComputer(professionals);
        professionals.Computer.DisplayConfiguration();
    }
}