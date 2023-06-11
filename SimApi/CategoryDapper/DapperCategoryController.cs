using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Operation;
using SimApi.Schema;

namespace SimApi.Service.CategoryDapper
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperCategoryController : ControllerBase
    {
        private readonly IDapperCategoryService categoryService;
        public DapperCategoryController(IDapperCategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ApiResponse<List<CategoryResponse>> GetAll()
        {
            var categoryList = categoryService.GetAll();
            return categoryList;
        }

        [HttpGet("{id}")]
        public ApiResponse<CategoryResponse> GetById(int id)
        {
            var category = categoryService.GetById(id);
            return category;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] CategoryRequest request)
        {
            return categoryService.Insert(request);
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] CategoryRequest request)
        {
            return categoryService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            return categoryService.Delete(id);
        }
    }
}
