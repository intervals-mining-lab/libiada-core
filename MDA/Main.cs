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
            MDA.Analisis.Form1 form1 = new MDA.Analisis.Form1();
            MDA.OIP.View.Form1 form = new MDA.OIP.View.Form1();
			form.Show();
            form1.Show();
			Application.Run();
	}
	
}