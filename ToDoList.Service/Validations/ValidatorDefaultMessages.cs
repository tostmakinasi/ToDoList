using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Service.Validations
{
    internal abstract class  ValidatorDefaultMessages
    {
        public static string RequiredMessage = "{PropertyName} is required!";
        public static string NotNullMessage = "{PropertyName} can't be null!";
        public static string MustGreaterMessage = "{PropertyName} must greater then 0";

    }
}
