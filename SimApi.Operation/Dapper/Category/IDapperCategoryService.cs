using SimApi.Data;
using SimApi.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation;

public interface IDapperCategoryService : IBaseService<Category, CategoryRequest, CategoryResponse>
{
}
