using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Service;
using ShoppingCart.WebApi.Model;

namespace ShoppingCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [Route("GetStocks")]


        public IActionResult GetStocks()
        {
            var stockServiceinfolst = _stockService.GetStocks();
            return Ok(stockServiceinfolst);
        }


        [HttpGet]
        [Route("GetStock")]

        public IActionResult GetStock(long StockId)
        {
            var stockServiceinfolst = _stockService.GetStock(StockId);
            return Ok(stockServiceinfolst);
        }

        [HttpPost]
        [Route("AddStock")]

        public async Task<ActionResult<StockModel>> AddStock(StockModel stockModel)
        {
            var stockserviceinfo = new StockServiceInfo();
            stockserviceinfo.StocktId = stockModel.StocktId;
            stockserviceinfo.ProductId = stockModel.ProductId;
            stockserviceinfo.Quantity = stockModel.Quantity;
            stockserviceinfo.CreatedBy = stockModel.CreatedBy;
            stockserviceinfo.ModifiedBy = stockModel.ModifiedBy;
            stockserviceinfo.CreatedDate = stockModel.CreatedDate;
            stockserviceinfo.ModifiedDate = stockModel.ModifiedDate;
            var result = _stockService.AddStock(stockserviceinfo);

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateStock")]

        public async Task<ActionResult<StockModel>> UpdateStock(StockModel stockModel)
        {
            var stockserviceinfo = new StockServiceInfo();
            stockserviceinfo.StocktId = stockModel.StocktId;
            stockserviceinfo.ProductId = stockModel.ProductId;
            stockserviceinfo.Quantity = stockModel.Quantity;
            stockserviceinfo.CreatedBy = stockModel.CreatedBy;
            stockserviceinfo.ModifiedBy = stockModel.ModifiedBy;
            // stockserviceinfo.CreatedDate= stockModel.CreatedDate;
            // stockserviceinfo.ModifiedDate= stockModel.ModifiedDate;
            _stockService.UpdateStock(stockserviceinfo);

            return Ok(stockserviceinfo);
        }

        [HttpDelete]
        [Route("DeleteStock")]

        public async Task<ActionResult> DeleteStock(long StockId)
        {
            _stockService.DeleteStock(StockId);
            return Ok();

        }



    }
}
