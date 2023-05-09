using productService;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.WebApi.Model;
using Microsoft.AspNetCore.Authorization;

namespace ShoppingCart.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProducts")]

        public IActionResult GetProducts()
        {
            var productServiceInfoList = _productService.GetProducts();
            return Ok(productServiceInfoList);
        }

        [HttpGet]
        [Route("GetProductId")]

        public async Task<IActionResult> GetProduct(int ProductId)
        {
            var productModel = _productService.GetProduct(ProductId);
            return Ok(productModel);
        }

        [HttpPost]
        [Route("AddProduct")]

        public async Task<ActionResult<ProductModel>> AddProduct(ProductModel productModel)
        {
            try
            {
                var productserviceinfo = new ProductServiceInfo();
                productserviceinfo.ProductId = productModel.ProductId;
                productserviceinfo.ProductName = productModel.ProductName;
                productserviceinfo.UnitPrice = productModel.UnitPrice;
                productserviceinfo.UnitDiscount = productModel.UnitDiscount;
                productserviceinfo.CreatedBy = productModel.CreatedBy;
                productserviceinfo.ModifiedBy = productModel.ModifiedBy;
                productserviceinfo.CreatedDate = productModel.CreatedDate;
                productserviceinfo.ModifiedDate = productModel.ModifiedDate;
                var result = _productService.AddProduct(productserviceinfo);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]

        public async Task<ActionResult<ProductModel>> UpdateProduct(ProductModel productModel)
        {
            try
            {
                if (productModel.ProductId != 0)
                {
                    var productserviceinfo = new ProductServiceInfo();
                    productserviceinfo.ProductId = productModel.ProductId;
                    productserviceinfo.ProductName = productModel.ProductName;
                    productserviceinfo.UnitPrice = productModel.UnitPrice;
                    productserviceinfo.UnitDiscount = productModel.UnitDiscount;
                    productserviceinfo.CreatedBy = productModel.CreatedBy;
                    productserviceinfo.ModifiedBy = productModel.ModifiedBy;
                    productserviceinfo.CreatedDate = productModel.CreatedDate;
                    productserviceinfo.ModifiedDate = productModel.ModifiedDate;
                    var result = _productService.UpdateProduct(productserviceinfo);

                    return Ok(result);
                }
                else
                {
                    return BadRequest("ProductId Not Exists");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct")]

        public async Task<ActionResult> DeleteProduct(int ProductId)
        {
            try
            {
                if (ProductId != 0)
                {
                    _productService.DeleteProduct(ProductId);
                    return Ok();
                }
                else
                {
                    return BadRequest("ProductId Not Exists");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

