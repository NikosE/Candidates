using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Common
{
   public class CommandResponse<T>
   {
      public T Data { get; set; }

      public CommandResponse<T> WithData(T data)
      {
         Data = data;
         return this;
      }
   }
}