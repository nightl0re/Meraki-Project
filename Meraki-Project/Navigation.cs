using System;
using System.Windows.Forms;

namespace Meraki_Project
{
    // Central form-to-form navigation.
    //
    // Program.cs uses Application.Run() WITHOUT a main form, so no single form's
    // closure kills the app. Instead, every form shown through this class is
    // tracked, and the app exits only when the LAST open form closes. This is
    // what makes "next.Show(); current.Close();" safe from any form, including
    // whichever one happened to be created first.
    internal static class Navigation
    {
        public static void Start(Form firstForm)
        {
            Track(firstForm);
            firstForm.Show();
            Application.Run();
        }

        public static void GoTo(Form current, Form next)
        {
            Track(next);
            next.Show();   // show the new form FIRST so OpenForms never hits zero mid-switch
            current.Close();
        }

        private static void Track(Form form)
        {
            form.FormClosed += (s, e) =>
            {
                if (Application.OpenForms.Count == 0)
                    Application.Exit();
            };
        }
    }
}
