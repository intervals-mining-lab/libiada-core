using System;


public class MyProgram
{
	public MyProgram (string [] args)
	{
		Program program = new Program ("MyProgram", "0.0", Modules.UI, args);
		App app = new App ("MyProgram", "MDA");
		app.SetDefaultSize (892, 562);
		app.DeleteEvent += new DeleteEventHandler (OnAppDelete);
		app.ShowAll ();
		program.Run ();
	}
	
	private void OnAppDelete (object o, DeleteEventArgs args)
	{
		Application.Quit ();
	}
}