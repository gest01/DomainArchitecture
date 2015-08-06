using System;

namespace Example.Web.Models
{
    /// <summary>
    /// Definiert das ViewModel für Fehler Seiten
    /// </summary>
    public class ErrorViewModel : ViewModel
    {
        public ErrorViewModel()
        {
            ReturnUrl = "/Home";
        }

        /// <summary>
        /// Fehlertext
        /// </summary>
        public String ErrorText { get; set; }

        /// <summary>
        /// Titel
        /// </summary>
        public String ErrorTitle { get; set; }

        public String ErrorRequestPath { get; set; }
        public String ReturnUrl { get; set; }

        public bool HasError { get; private set; }

        /// <summary>
        /// Erstellt ein ErrorViewModel basierend auf einer Exception
        /// </summary>
        /// <param name="error">Exception die aufgetreten ist</param>
        /// <param name="defaultTitle">Default ErrorTitle</param>
        /// <returns>ErrorViewModel</returns>
        public static ErrorViewModel CreateFromError(Exception error, String defaultTitle)
        {
            ErrorViewModel viewmodel = new ErrorViewModel();
            viewmodel.ErrorTitle = defaultTitle;
            viewmodel.HasError = error != null;
            if (viewmodel.HasError)
            {
                //if (error is CustomException1)
                //{
                //    viewmodel.ErrorTitle = "Custom Exception 1";
                //}

                //if (error is CustomException2)
                //{
                //    viewmodel.ErrorTitle = "Custom Exception 2";
                //}

                viewmodel.ErrorText = error.ToString();
            }

            return viewmodel;
        }
    }
}