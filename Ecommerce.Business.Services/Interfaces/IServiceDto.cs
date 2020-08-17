using Ecommerce.Business.Dto;
using Ecommerce.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IServiceDto<T> where T: BaseDto 
    {
        int Create(T entity);

        T Read(int id);

        IEnumerable<T> Read();

        IEnumerable<T> Read(ProductFilterDto productFilterDto);

        T Update(T entity);

        void Delete(int id);
    }
}
