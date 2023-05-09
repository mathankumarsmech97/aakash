
using ShoppingCart.Store;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingCart.Service
{

    public interface IReturnService
    {
        List<ReturnView> GetReturns();
        ArrayList AddReturn(ReturnServiceInfo returnServiceInfo);

        ReturnServiceInfo GetReturn(long ReturnID);

        void UpdateReturn(ReturnServiceInfo returnServiceInfo);

        void DeleteReturn(long ReturnID);
        //ArrayList DeleteReturn(long  ReturnID);
    }

    public class ReturnService : IReturnService
    {
        private readonly IReturnStore _returnStore;

        private readonly IPurchaseStore _purchaseStore;


        public ReturnService(IReturnStore returnStore, IPurchaseStore purchaseStore)
        {
            _returnStore = returnStore;
            _purchaseStore = purchaseStore;
        }


        public List<ReturnView> GetReturns()
        {
            var returnStoreInfo = _returnStore.GetReturns();

            if (returnStoreInfo == null)
            {
                return null;
            }
            else
            {
                var returnLst = new List<ReturnView>();
                foreach (var storeInfo in returnStoreInfo)
                {
                    returnLst.Add(new ReturnView
                    {
                        //ReturnID = storeInfo.ReturnID,
                        PurchaseID = storeInfo.PurchaseID,
                        ProductID = storeInfo.ProductID,
                        ProductName = storeInfo.ProductName,
                        ReturnedQuantity = storeInfo.ReturnedQuantity,
                        ReturnedTotalDiscount = storeInfo.ReturnedTotalDiscount,
                        ReturnedTotalAmount = storeInfo.ReturnedTotalAmount,
                        ReturnedDate = storeInfo.ReturnedDate,
                        UnitPrice = storeInfo.UnitPrice,
                        UnitDiscount = storeInfo.UnitDiscount,


                    });
                }
                return returnLst;
            }
        }
        public ReturnServiceInfo GetReturn(long ReturnID)
        {

            var returnStoreInfo = _returnStore.GetReturn(ReturnID);
            if (returnStoreInfo == null)
            {
                return null;
            }

            else
            {
                return new ReturnServiceInfo
                {
                    ReturnID = returnStoreInfo.ReturnID,
                    PurchaseID = returnStoreInfo.PurchaseID,
                    ProductID = returnStoreInfo.ProductID,
                    ReturnedQuantity = returnStoreInfo.ReturnedQuantity,
                    ReturnedTotalDiscount = returnStoreInfo.ReturnedTotalDiscount,
                    ReturnedTotalAmount = returnStoreInfo.ReturnedTotalAmount,
                    ReturnedDate = returnStoreInfo.ReturnedDate,
                    CreatedBy = returnStoreInfo.CreatedBy,
                    ModifiedBy = returnStoreInfo.ModifiedBy,
                    CreatedDate = returnStoreInfo.CreatedDate,
                    ModifiedDate = returnStoreInfo.ModifiedDate,

                };
            }
        }
        public ArrayList AddReturn(ReturnServiceInfo returnServiceInfo)
        {

            var valid = ValidatePurchaseReturn(returnServiceInfo);
            if (valid.Count == 0)
            {
                var exist = IsPurchaseReturnExist(returnServiceInfo);
                if (exist.Count == 0)
                {
                    var returnStoreInfo = new ReturnStoreInfo();
                    returnStoreInfo.ReturnID = returnServiceInfo.ReturnID;
                    returnStoreInfo.PurchaseID = returnServiceInfo.PurchaseID;
                    returnStoreInfo.ProductID = returnServiceInfo.ProductID;
                    returnStoreInfo.ReturnedQuantity = returnServiceInfo.ReturnedQuantity;
                    returnStoreInfo.ReturnedTotalDiscount = returnServiceInfo.ReturnedTotalDiscount;
                    returnStoreInfo.ReturnedTotalAmount = returnServiceInfo.ReturnedTotalAmount;
                    returnStoreInfo.ReturnedDate = returnServiceInfo.ReturnedDate;
                    returnStoreInfo.CreatedBy = returnServiceInfo.CreatedBy;
                    returnStoreInfo.ModifiedBy = returnServiceInfo.ModifiedBy;
                    returnStoreInfo.CreatedDate = returnServiceInfo.CreatedDate;
                    returnStoreInfo.ModifiedDate = returnServiceInfo.ModifiedDate;

                    _returnStore.AddReturn(returnStoreInfo);
                }
                else
                {
                    return exist;
                }
            }
            else
            {
                return valid;
            }
            return valid;
        }

        public void UpdateReturn(ReturnServiceInfo returnServiceInfo)
        {
            var returnStoreInfo = new ReturnStoreInfo();
            returnStoreInfo.ReturnID = returnServiceInfo.ReturnID;
            returnStoreInfo.PurchaseID = returnServiceInfo.PurchaseID;
            returnStoreInfo.ProductID = returnServiceInfo.ProductID;
            returnStoreInfo.ReturnedQuantity = returnServiceInfo.ReturnedQuantity;
            returnStoreInfo.ReturnedTotalDiscount = returnServiceInfo.ReturnedTotalDiscount;
            returnStoreInfo.ReturnedTotalAmount = returnServiceInfo.ReturnedTotalAmount;
            returnStoreInfo.ReturnedDate = returnServiceInfo.ReturnedDate;
            returnStoreInfo.CreatedBy = returnServiceInfo.CreatedBy;
            returnStoreInfo.ModifiedBy = returnServiceInfo.ModifiedBy;
            returnStoreInfo.CreatedDate = returnServiceInfo.CreatedDate;
            returnStoreInfo.ModifiedDate = returnServiceInfo.ModifiedDate;
            _returnStore.UpdateReturn(returnStoreInfo);
        }

        public void DeleteReturn(long ReturnID)
        {
            //var valid = ValidateDeleteReturn(long ReturnID);
            _returnStore.DeleteReturn(ReturnID);
        }
        //public ArrayList DeleteReturn (long ReturnID)
        //{
        //    //var returnstoreinfo = new ReturnStoreInfo();
        //    //returnstoreinfo.ReturnID = ReturnID;
        //    var valid = ValidateDeleteReturn(returnServiceInfo);
        //    if(valid.Count== 0)
        //    {
        //        //var returnstoreinfo = new ReturnStoreInfo();
        //        //returnstoreinfo.ReturnID = ReturnID;
        //        _returnStore.DeleteReturn(ReturnID);
        //    }
        //    return valid;


        //}
        public ArrayList ValidateDeleteReturn(ReturnServiceInfo returnServiceInfo)
        {
            ArrayList arrayList = new ArrayList();
            var res = _purchaseStore.GetPurchaseId(returnServiceInfo.PurchaseID);

            if (res == null)
            {
                arrayList.Add("ReturnID Is Not Exists");
                return arrayList;
            }
            if (res.PurchaseID != returnServiceInfo.PurchaseID)
            {
                arrayList.Add("PurchaseID Is Not Exists");
            }

            return arrayList;

        }

        private ArrayList ValidatePurchaseReturn(ReturnServiceInfo returnServiceInfo)
        {
            ArrayList list = new ArrayList();

            if (returnServiceInfo.PurchaseID <= 0)
            {
                list.Add("PurchaseID does not Exists");
            }
            if (returnServiceInfo.ProductID <= 0)
            {
                list.Add("ProductID Does Not Exists");
            }
            if (returnServiceInfo.ReturnedQuantity <= 0)
            {
                list.Add("ReturnedQuantity Does Not Exists");
            }
            return list;
        }

        private ArrayList IsPurchaseReturnExist(ReturnServiceInfo returnServiceInfo)
        {
            ArrayList list = new ArrayList();
            var PurchaseDetails = _purchaseStore.GetPurchaseId(returnServiceInfo.PurchaseID);
            // var result = purchaseReturn.ProductID == returnServiceInfo.ProductID);
            if (PurchaseDetails == null)
            {
                list.Add("PurchaseID Is Not Exists");
                return list;
            }

            if (PurchaseDetails.ProductID != returnServiceInfo.ProductID)
            {
                list.Add("ProductId Not Exists");
            }
            //var result1 = purchaseReturn.Any(q => q.ReturnedQuantity > returnServiceInfo.ReturnedQuantity);
            if (returnServiceInfo.ReturnedQuantity > PurchaseDetails.Quantity)
            {
                list.Add("ReturnedQuantity MissMatched");
            }
            //var result2 = PurchaseDetails.Any(P => P.PurchaseID== PurchaseID);
            //if (result2)
            //{
            //    list.Add("PurchaseID Already Exists");
            //}

            return list;
        }


    }
}
