using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Common
{
   public class Response<T>
   {
      public T Data { get; set; }

      public Response<T> WithData(T data)
      {
         Data = data;
         return this;
      }
   }
}