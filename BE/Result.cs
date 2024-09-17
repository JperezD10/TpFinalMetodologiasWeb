using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Result<T>
    {
        //lo hago privado para obligar a usar los metodos estaticos
        private Result()
        {
            
        }
        public bool Ok { get; set; } = true;
        public string Message { get; set; }
        public T Data { get; set; }

        public static Result<T> Success(T data, string message = "")
        {
            return new Result<T> { Ok = true, Message = message, Data = data };
        }

        public static Result<T> Error(string message, T data)
        {
            return new Result<T> { Data = data, Message = message, Ok = false};
        }
    }
}
