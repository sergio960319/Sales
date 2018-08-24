namespace Sales.Common.Models
{

    using System;
    using System.Threading.Tasks;

   public class Response
    {        
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }                  
    }
}
