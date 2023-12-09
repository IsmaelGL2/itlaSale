using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Application.Core
{
    public interface IBaseServices<TDtoAdd, TDtoUpdate, TDtoDelete> 
    {
        ServicesResult GetAll();
        ServicesResult GetById(int Id);

        ServicesResult Save(TDtoAdd dtoAdd);
        ServicesResult Delete(TDtoDelete dtoDelete);
        ServicesResult Update(TDtoUpdate dtoUpdate);
    }
}
