using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Service;
using ShoppingCart.Store;
using ShoppingCart.WebApi.Model;

namespace ShoppingCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ControllerBase
    {
        private readonly IReturnService _returnService;

        public ReturnController(IReturnService returnService)
        {
            _returnService = returnService;
        }


        [HttpGet]
        [Route("GetReturns")]
        public IActionResult GetReturns()
        {
            var returnLst = _returnService.GetReturns();
            return Ok(returnLst);
        }

        [HttpGet]
        [Route("GetReturn")]
        public IActionResult GetReturn(long ReturnID)
        {
            var returnStoreInfo = _returnService.GetReturn(ReturnID);
            return Ok(returnStoreInfo);
        }


        [HttpPost]
        [Route("AddReturn")]
        public async Task<ActionResult<ReturnModel>> AddReturn(ReturnModel returnModel)
        {
            var returnserviceinfo = new ReturnServiceInfo();
            returnserviceinfo.ReturnID = returnModel.ReturnID;
            returnserviceinfo.PurchaseID = returnModel.PurchaseID;
            returnserviceinfo.ProductID = returnModel.ProductID;
            returnserviceinfo.ReturnedQuantity = returnModel.ReturnedQuantity;
            returnserviceinfo.ReturnedTotalDiscount = returnModel.ReturnedTotalDiscount;
            returnserviceinfo.ReturnedTotalAmount = returnModel.ReturnedTotalAmount;
            returnserviceinfo.ReturnedDate = returnModel.ReturnedDate;
            returnserviceinfo.CreatedBy = returnModel.CreatedBy;
            returnserviceinfo.ModifiedBy = returnModel.ModifiedBy;
            returnserviceinfo.CreatedDate = returnModel.CreatedDate;
            returnserviceinfo.ModifiedDate = returnModel.ModifiedDate;
            var result = _returnService.AddReturn(returnserviceinfo);

            return Ok(result);
        }


        [HttpPut]
        [Route("UpdateReturn")]
        public async Task<ActionResult<ReturnModel>> UpdateReturn(ReturnModel returnModel)
        {
            var returnserviceinfo = new ReturnServiceInfo();
            returnserviceinfo.ReturnID = returnModel.ReturnID;
            returnserviceinfo.PurchaseID = returnModel.PurchaseID;
            returnserviceinfo.ProductID = returnModel.ProductID;
            returnserviceinfo.ReturnedQuantity = returnModel.ReturnedQuantity;
            returnserviceinfo.ReturnedTotalDiscount = returnModel.ReturnedTotalDiscount;
            returnserviceinfo.ReturnedTotalAmount = returnModel.ReturnedTotalAmount;
            returnserviceinfo.ReturnedDate = returnModel.ReturnedDate;
            returnserviceinfo.CreatedBy = returnModel.CreatedBy;
            returnserviceinfo.ModifiedBy = returnModel.ModifiedBy;
            returnserviceinfo.CreatedDate = returnModel.CreatedDate;
            returnserviceinfo.ModifiedDate = returnModel.ModifiedDate;
            _returnService.UpdateReturn(returnserviceinfo);

            return Ok(returnserviceinfo);
        }


        [HttpDelete]
        [Route("DeleteReturn")]

        public ActionResult DeleteReturn(long ReturnID)
        {
            try
            {
                _returnService.DeleteReturn(ReturnID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

