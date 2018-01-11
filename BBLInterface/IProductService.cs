using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBLInterface
{
    public interface IProductService
    {
        OperationResult GetById(ProductDTO model);

        OperationResult GetAll();

        OperationResult Add(ProductDTO model);

        OperationResult Update(ProductDTO model);

        OperationResult Delete(ProductDTO model);
    }
}
