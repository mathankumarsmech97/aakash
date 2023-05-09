using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Service;
using ShoppingCart.WebApi.Model;

namespace ShoppingCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }


        [HttpGet]
        [Route("GetPurchase")]


        public IActionResult GetPurchase()
        {
            var purchaseLst = _purchaseService.GetPurchase();
            return Ok(purchaseLst);
        }


        [HttpGet]
        [Route("GetPurchaseId")]


        public IActionResult GetPurchaseId(long purchaseId)
        {
            var purchaseStoreInfo = _purchaseService.GetPurchaseId(purchaseId);
            return Ok(purchaseStoreInfo);
        }



        [HttpPost]
        [Route("AddPurchase")]

        public async Task<ActionResult<PurchaseModel>> AddPurchase(PurchaseModel purchaseModel)
        {
            var purchaseServiceInfo = new PurchaseServiceInfo();
            purchaseServiceInfo.PurchaseID = purchaseModel.PurchaseID;
            purchaseServiceInfo.ProductID = purchaseModel.ProductID;
            purchaseServiceInfo.Quantity = purchaseModel.Quantity;
            purchaseServiceInfo.UnitPrice = purchaseModel.UnitPrice;
            purchaseServiceInfo.UnitDiscount = purchaseModel.UnitDiscount;
            purchaseServiceInfo.TotalDiscount = purchaseModel.TotalDiscount;
            purchaseServiceInfo.TotalAmount = purchaseModel.TotalAmount;
            purchaseServiceInfo.PurchasedDate = purchaseModel.PurchasedDate;
            purchaseServiceInfo.CreatedBy = purchaseModel.CreatedBy;
            purchaseServiceInfo.ModifiedBy = purchaseModel.ModifiedBy;
            purchaseServiceInfo.CreatedDate = purchaseModel.CreatedDate;
            purchaseServiceInfo.ModifiedDate = purchaseModel.ModifiedDate;
            var result = _purchaseService.AddPurchase(purchaseServiceInfo);

            return Ok(result);
        }


        [HttpPut]
        [Route("UpdatePurchase")]


        public async Task<ActionResult<PurchaseModel>> UpdatePurchase(PurchaseModel purchaseModel)
        {
            var purchaseServiveInfo = new PurchaseServiceInfo();
            purchaseServiveInfo.PurchaseID = purchaseModel.PurchaseID;
            purchaseServiveInfo.ProductID = purchaseModel.ProductID;
            purchaseServiveInfo.Quantity = purchaseModel.Quantity;
            purchaseServiveInfo.UnitPrice = purchaseModel.UnitPrice;
            purchaseServiveInfo.UnitDiscount = purchaseModel.UnitDiscount;
            purchaseServiveInfo.TotalDiscount = purchaseModel.TotalDiscount;
            purchaseServiveInfo.TotalAmount = purchaseModel.TotalAmount;
            purchaseServiveInfo.PurchasedDate = purchaseModel.PurchasedDate;
            purchaseServiveInfo.CreatedBy = purchaseModel.CreatedBy;
            purchaseServiveInfo.ModifiedBy = purchaseModel.ModifiedBy;
            purchaseServiveInfo.CreatedDate = purchaseModel.CreatedDate;
            purchaseServiveInfo.ModifiedDate = purchaseModel.ModifiedDate;
            _purchaseService.UpdatePurchase(purchaseServiveInfo);

            return Ok(purchaseServiveInfo);
        }


        [HttpDelete]
        [Route("DeletePurchase")]

        public async Task<ActionResult<PurchaseModel>> DeletePurchase(long PurchaseId)
        {
            _purchaseService.DeletePurchase(PurchaseId);
            return Ok();
        }
    }
}
