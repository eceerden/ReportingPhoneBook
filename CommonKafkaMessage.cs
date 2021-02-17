using System;

public class Reportmessage
{
	
    public int ID { get; set; }
    public string location { get; set; }
    public int Countperson { get; set; }
    public int Countnumber { get; set; }
    public DateTime Requesttime { get; set; } = DateTime.Now;
    public bool Reportstatus { get; set; }

}
