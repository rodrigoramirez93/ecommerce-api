using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public class ControllersHelperMethods
    {
        public void ApiAction(Action action)
        {
            try
            {
                action();
            }
            catch(Exception e)
            {
                throw new Exception($"Something wrong happend: {e.Message}");
            }
        }
    }
}
