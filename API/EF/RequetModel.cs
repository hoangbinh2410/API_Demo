using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EF
{
    public class RequetModel<T>
    {
        public T data { get; set; }
        public bool success { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
