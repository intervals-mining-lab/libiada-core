using System;
using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;

public class MainClass
{
    [STAThread]
	public static void Main (string[] args)
	{
		    Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MDA.Analisis.Form1 form = new MDA.Analisis.Form1();
			form.Show();
			Application.Run();
	}
	
}