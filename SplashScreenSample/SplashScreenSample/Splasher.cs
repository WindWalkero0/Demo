using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplashScreenSample
{
    public class Splasher
    {
        private static Form m_SplashForm = null;
        private static ISplashForm m_SplashInterface = null;
        private static Thread m_SplashThread = null;
        private static string m_TempStatus = string.Empty;

        private delegate void SplashStatusChangedHandle(string NewStatusInfo);

        /// <summary>
        /// 显示闪屏
        /// </summary>
        /// <param name="splashFormType"></param>
        public static void Show(Type splashFormType)
        {
            if (m_SplashThread != null)
                return;
            if (splashFormType == null)
            {
                throw new Exception("splashFormType is null");
            }

            m_SplashThread = new Thread(new ThreadStart(delegate ()
            {
                CreateInstance(splashFormType);
                Application.Run(m_SplashForm);
            }));
            m_SplashThread.IsBackground = true;
            m_SplashThread.SetApartmentState(ApartmentState.STA);
            m_SplashThread.Start();
        }

        public static string Status
        {
            set
            {
                if(m_SplashForm == null || m_SplashThread == null)
                {
                    m_TempStatus = value;
                    return;
                }
                m_SplashForm.Invoke(
                    new SplashStatusChangedHandle(delegate (string str) { m_SplashInterface.SetStatusInfo(str); }),
                    new object[] { value }
                    );
            }
        }

        public static void Close()
        {
            if (m_SplashForm == null || m_SplashThread == null)
                return;
            try
            {
                m_SplashForm.Invoke(new MethodInvoker(m_SplashForm.Close));
            }
            catch(Exception)
            { }
            m_SplashForm = null;
            m_SplashThread = null;
        }

        private static void CreateInstance(Type FormType)
        {
            object obj = Activator.CreateInstance(FormType);

            m_SplashForm = obj as Form;
            m_SplashInterface = obj as ISplashForm;
            if(m_SplashForm == null)
            {
                throw new Exception("Splash Screen must inherit from System.Windows.Forms.Form");
            }
            if(m_SplashInterface == null)
            {
                throw new Exception("must implement interface ISplashForm");
            }
            if(!string.IsNullOrEmpty(m_TempStatus))
            {
                m_SplashInterface.SetStatusInfo(m_TempStatus);
            }
        }
    }
}
