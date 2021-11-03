using System;
using System.Text;


interface ILitery
{
    public string ShowAlfa();
}

interface ICyfry
{
    public string ShowNum();
}


class AlfabetFactory
{

    private SystemFactory systemFactory;
    public ICyfry numbers;
    public ILitery letters;

    public AlfabetFactory(SystemFactory systemFactory)
    {
        this.systemFactory = systemFactory;
    }

    public void Generate()
    {
        letters = systemFactory.CreateAlfa();
        numbers = systemFactory.CreateNum();
    }

}


abstract class SystemFactory
{
    public abstract ILitery CreateAlfa();
    public abstract ICyfry CreateNum();
}

class LacinaFactory : SystemFactory
{
    public override ILitery CreateAlfa()
    {
        return new LacinaLetters();
    }

    public override ICyfry CreateNum()
    {
        return new LacinaNumbers();
    }
}
class GrekaFactory : SystemFactory
{
    public override ILitery CreateAlfa()
    {
        return new GrekaLetters();
    }

    public override ICyfry CreateNum()
    {
        return new GrekaNumbers();
    }
}
class CyrylicaFactory : SystemFactory
{
    public override ILitery CreateAlfa()
    {
        return new CyrylicaLetters();
    }

    public override ICyfry CreateNum()
    {
        return new CyrylicaNumbers();
    }
}


class LacinaLetters : ILitery
{
    public string letters;

    public LacinaLetters()
    {
        letters = "abcde";
    }
    public string ShowAlfa()
    {
        return letters;
    }
}

class LacinaNumbers : ICyfry
{
    public string numbers;

    public LacinaNumbers()
    {
        numbers = "I II III";
    }

    public string ShowNum()
    {
        return numbers;
    }
}


class CyrylicaLetters : ILitery
{
    string letters;

    public CyrylicaLetters()
    {
        letters = "абвгд";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}


class CyrylicaNumbers : ICyfry
{
    string numbers;

    public CyrylicaNumbers()
    {
        numbers = "123";
    }

    public string ShowNum()
    {
        return numbers;
    }
}


class GrekaLetters : ILitery
{
    string letters;
    public GrekaLetters()
    {
        letters = "αβγδε";
    }

    public string ShowAlfa()
    {
        return letters;
    }
}
class GrekaNumbers : ICyfry
{
    string numbers;
    public GrekaNumbers()
    {
        numbers = "αʹβʹγʹ";
    }

    public string ShowNum()
    {
        return numbers;
    }
}

public class Application
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        AlfabetFactory alfabet_lacina = new AlfabetFactory(new LacinaFactory());
        AlfabetFactory cyfry_lacina = new AlfabetFactory(new LacinaFactory());
        AlfabetFactory alfabet_cyrylica = new AlfabetFactory(new GrekaFactory());
        AlfabetFactory cyfry_cyrylica = new AlfabetFactory(new GrekaFactory());
        AlfabetFactory alfabet_greka = new AlfabetFactory(new CyrylicaFactory());
        AlfabetFactory cyfry_greka = new AlfabetFactory(new CyrylicaFactory());

        alfabet_lacina.Generate();
        cyfry_lacina.Generate();
        Console.WriteLine($"{alfabet_lacina.letters.ShowAlfa()} {alfabet_lacina.numbers.ShowNum()}");

        alfabet_cyrylica.Generate();
        cyfry_cyrylica.Generate();
        Console.WriteLine($"{alfabet_cyrylica.letters.ShowAlfa()} {alfabet_cyrylica.numbers.ShowNum()}");

        alfabet_greka.Generate();
        cyfry_greka.Generate();
        Console.WriteLine($"{alfabet_greka.letters.ShowAlfa()} {alfabet_greka.numbers.ShowNum()}");

    }
}
