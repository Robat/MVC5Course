using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    internal class testaudAttribute : DataTypeAttribute
    {
        public testaudAttribute() : base(DataType.Text)
        {
        }

        public override bool IsValid(object value)
        {
            var str = (string)value;

            return str.Contains(" ");
        }
    }
}