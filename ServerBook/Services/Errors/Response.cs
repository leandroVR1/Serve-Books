using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerBook.Services.Errors
{
    public class Response<T>
    {
         public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
       
       

        public void ValidarNumeroInferiorACero(Response<T> response,int value, string valueErrorMenssage)
        {
            if(value <= 0)
            {
                response.ErrorMessage = valueErrorMenssage;
                response.Success = false;
            }
        }

        public void ValidarTextosNullOVacios(Response<T> response, string value, string valueErrorMenssage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                response.ErrorMessage = valueErrorMenssage;
                response.Success = false;
            }
        }

        public void Catch(Response<T> response, string valueErrorMenssage)
        {
            response.ErrorMessage = valueErrorMenssage;
            response.Success = false;
        }

        public void ValidarValorDiferenteANull(Response<T> response, dynamic value, string valueErrorMenssage)
        {
            if(value != null)
            {
                response.ErrorMessage = valueErrorMenssage;
                response.Success = false;
            }
        }

        public void ValidarValorIgualANull(Response<T> response, dynamic value, string valueErrorMenssage)
        {
            if (value == null)
            {
                response.ErrorMessage = valueErrorMenssage;
                response.Success = false;
            }
        }

        public Response(string message, T data, bool success = true)
        {
            Message = message;
            Data = data;
            Success = success;
        }


    }
}