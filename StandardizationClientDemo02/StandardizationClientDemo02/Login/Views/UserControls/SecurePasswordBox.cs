/*
SecurePasswordBox class
*/

using System.Windows.Controls;
using System.Windows;

namespace StandardizationClientDemo02.Login.Views.UserControls
{
    /// <summary>
    /// More secure PasswordBox based on TextBox control
    /// </summary>
    public class SecurePasswordBox : TextBox
    {
        // Fake char to display in Visual Tree
        private char PWD_CHAR = '●';

        /// <summary>
        /// Only copy of real password
        /// </summary>
        /// <remarks>For more security use System.Security.SecureString type instead</remarks>
        private string _password = string.Empty;

        /// <summary>
        /// TextChanged event handler for secure storing of password into Visual Tree,
        /// text is replaced with PWD_CHAR chars, clean text is keept into
        /// Text property (CLR property not snoopable without mod)   
        /// </summary>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (dirtyBaseText == true)
                return;

            string currentText = this.BaseText;

            int selStart = this.SelectionStart;
            if (currentText.Length < _password.Length)
            {
                // Remove deleted chars          
                _password = _password.Remove(selStart, _password.Length - currentText.Length);
                SetRealText(this, _password);
            }
            if (!string.IsNullOrEmpty(currentText))
            {
                for (int i = 0; i < currentText.Length; i++)
                {
                    if (currentText[i] != PWD_CHAR)
                    {
                        // Replace or insert char
                        if (this.BaseText.Length == _password.Length)
                        {
                            _password = _password.Remove(i, 1).Insert(i, currentText[i].ToString());
                        }
                        else
                        {
                            _password = _password.Insert(i, currentText[i].ToString());
                        }
                    }
                }
                SetRealText(this, _password);
                this.BaseText = new string(PWD_CHAR, _password.Length);
                this.SelectionStart = selStart;
            }
            base.OnTextChanged(e);
        }

        // flag used to bypass OnTextChanged
        private bool dirtyBaseText;

        /// <summary>
        /// Provide access to base.Text without call OnTextChanged 
        /// </summary>
        private string BaseText
        {
            get { return base.Text; }
            set
            {
                dirtyBaseText = true;
                base.Text = value;
                dirtyBaseText = false;
            }
        }

        /// <summary>
        /// Clean Password
        /// </summary>
        public new string Text
        {
            get { return _password; }
            set
            {
                _password = value;
                this.BaseText = new string(PWD_CHAR, value.Length);
            }
        }




        public static string GetRealText(DependencyObject obj)
        {
            return (string)obj.GetValue(RealTextProperty);
        }

        public static void SetRealText(DependencyObject obj, string value)
        {
            obj.SetValue(RealTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for RealText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RealTextProperty =
            DependencyProperty.RegisterAttached("RealText", typeof(string), typeof(SecurePasswordBox), new UIPropertyMetadata(""));

    }
}