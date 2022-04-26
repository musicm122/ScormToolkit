using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Ioc;
using ScormLogic.ViewModel;

namespace ScormToolkit_Wpf
{
    public static class AppBootstrap
    {
        public static void Init()
        {
            if (!SimpleIoc.Default.IsRegistered<ViewModelLocator>())
            {
                SimpleIoc.Default.Register<ViewModelLocator>(() =>
                {
                    return new ViewModelLocator();
                }, true);
            }
        }

    }
}
