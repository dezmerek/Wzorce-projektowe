using System;


public interface ITelewizor
{

	int Kanal { get; set; }
	void Wlacz();
	void Wylacz();
	void ZmienKanal(int kanal);

}



public class TvLg : ITelewizor
{

	public TvLg()
	{
		this.Kanal = 1;
	}

	public int Kanal { get; set; }

	public void Wlacz()
	{
		Console.WriteLine("Telewizor LG włączony.");
	}

	public void Wylacz()
	{
		Console.WriteLine("Telewizor LG wyłączony.");
	}

	public void ZmienKanal(int kanal)
	{
		Kanal = kanal;
		Console.WriteLine("Telewizor LG, kanał: " + Kanal);
	}

}



public class TvPhilips : ITelewizor
{

	public TvPhilips()
	{
		this.Kanal = 1;
	}

	public int Kanal { get; set; }

	public void Wlacz()
	{
		Console.WriteLine("Telewizor Philips włączony.");
	}

	public void Wylacz()
	{
		Console.WriteLine("Telewizor Philips wyłączony.");
	}

	public void ZmienKanal(int kanal)
	{
		Kanal = kanal;
		Console.WriteLine("Telewizor Philips, kanał: " + Kanal);
	}

}



public abstract class PilotAbstrakcyjny
{

	private ITelewizor tv;

	public PilotAbstrakcyjny(ITelewizor tv)
	{
		this.tv = tv;
	}
	public void Wlacz()
	{
		tv.Wlacz();
	}
	public void Wylacz()
	{
		tv.Wylacz();
	}
	public void ZmienKanal(int kanal)
	{
		tv.ZmienKanal(kanal);

	}

}



public class PilotHarmony : PilotAbstrakcyjny
{

	public PilotHarmony(ITelewizor tv) : base(tv) { }

	public void DoWlacz()
	{
		Console.WriteLine("Pilot Harmony włącza telewizor...");
		Wlacz();
	}
	public void DoWylacz()
	{
		Console.WriteLine("Pilot Harmony wyłącza telewizor...");
		Wylacz();
	}
	public void DoZmienKanal(int kanal)
	{
		Console.WriteLine("Pilot Harmony zmienia kanał...");
		ZmienKanal(kanal);
	}

}

public class PilotPhilips : PilotAbstrakcyjny
{
	public PilotPhilips(ITelewizor tv) : base(tv) { }

	public void DoZmienKanal(int kanal)
	{
		Console.WriteLine("Pilot Philips zmienia kanał");
		ZmienKanal(kanal);
	}

	public void DoWlacz()
	{
		Console.WriteLine("Pilot Philips włącza telewizor...");
		Wlacz();
	}

	public void DoWylacz()
	{
		Console.WriteLine("Pilot Philips wyłącza telewizor...");
		Wylacz();
	}

}



class MainClass
{
	public static void Main(string[] args)
	{

		ITelewizor tv = new TvLg();
		PilotHarmony pilotHarmony = new PilotHarmony(tv);

		ITelewizor tv2 = new TvPhilips();
		PilotPhilips pilotPhilips = new PilotPhilips(tv2);

		pilotHarmony.DoWlacz();
		Console.WriteLine("Kanał: " + tv.Kanal);
		pilotPhilips.DoWlacz();
		pilotPhilips.DoZmienKanal(100);
		Console.WriteLine("Kanał: " + tv2.Kanal);

	}
}