using Ecommerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IServiceDto<T> where T: BaseDto 
    {
        T Create(T entity);

        T Read(int id);

        IEnumerable<T> Read();

        T Update(T entity);

        T Delete(int id);
    }
}
