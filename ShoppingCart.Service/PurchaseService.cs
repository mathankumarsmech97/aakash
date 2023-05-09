
using ShoppingCart.Store;
using System.Collections;

namespace ShoppingCart.Service
{
    public interface IPurchaseService
    {
        List<PurchaseList> GetPurchase();

        PurchaseServiceInfo GetPurchaseId(long PurchaseID);

        ArrayList AddPurchase(PurchaseServiceInfo purchaseServiceInfo);


        void UpdatePurchase(PurchaseServiceInfo purchaseServiceInfo);

        void DeletePurchase(long PurchaseID);


    }

    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseStore _purchaseStore;

        public PurchaseService(IPurchaseStore purchaseStore)
        {
            _purchaseStore = purchaseStore;
        }


        public List<PurchaseList> GetPurchase()
        {
            var purchaseStoreInfo = _purchaseStore.GetPurchase();

            if (purchaseStoreInfo == null)
            {
                return null;
            }

            else
            {
                var purchaseLst = new List<PurchaseList>();
                foreach (var storeInfo in purchaseStoreInfo)
                {
                    purchaseLst.Add(new PurchaseList
                    {
                        ProductID = storeInfo.ProductID,
                        ProductName = storeInfo.ProductName,
                        PurchasedDate = storeInfo.PurchasedDate,
                        Quantity = storeInfo.Quantity,
                        TotalDiscount = storeInfo.TotalDiscount,
                        TotalAmount = storeInfo.TotalAmount,
                        ReturnedDate = storeInfo.ReturnedDate,
                        ReturnedQuantity = storeInfo.ReturnedQuantity,
                        ReturnedTotalDiscount = storeInfo.ReturnedTotalDiscount,
                        ReturnedTotalAmount = storeInfo.ReturnedTotalAmount,


                    });
                }
                return purchaseLst;
            }
        }

        public PurchaseServiceInfo GetPurchaseId(long PurchaseID)
        {
            var purchaseStoreInfo = _purchaseStore.GetPurchaseId(PurchaseID);

            if (purchaseStoreInfo == null)
            {
                return null;
            }

            else
            {
                return new PurchaseServiceInfo
                {
                    PurchaseID = purchaseStoreInfo.PurchaseID,
                    ProductID = purchaseStoreInfo.ProductID,
                    Quantity = purchaseStoreInfo.Quantity,
                    UnitPrice = purchaseStoreInfo.UnitPrice,
                    UnitDiscount = purchaseStoreInfo.UnitDiscount,
                    TotalDiscount = purchaseStoreInfo.TotalDiscount,
                    TotalAmount = purchaseStoreInfo.TotalAmount,
                    PurchasedDate = purchaseStoreInfo.PurchasedDate,
                    CreatedBy = purchaseStoreInfo.CreatedBy,
                    ModifiedBy = purchaseStoreInfo.ModifiedBy,
                    CreatedDate = purchaseStoreInfo.CreatedDate,
                    ModifiedDate = purchaseStoreInfo.ModifiedDate,


                };

            }
        }

        public ArrayList AddPurchase(PurchaseServiceInfo purchaseServiceInfo)
        {
            var valid = ValidatePurchase(purchaseServiceInfo);
            if (valid.Count == 0)
            {
                var exist = IsPurchaseExist(purchaseServiceInfo.ProductID, purchaseServiceInfo.Quantity);
                if (exist.Count == 0)
                {
                    var purchaseStoreInfo = new PurchaseStoreInfo();
                    purchaseStoreInfo.PurchaseID = purchaseServiceInfo.PurchaseID;
                    purchaseStoreInfo.ProductID = purchaseServiceInfo.ProductID;
                    purchaseStoreInfo.Quantity = purchaseServiceInfo.Quantity;
                    purchaseStoreInfo.UnitPrice = purchaseServiceInfo.UnitPrice;
                    purchaseStoreInfo.UnitDiscount = purchaseServiceInfo.UnitDiscount;
                    purchaseStoreInfo.TotalDiscount = purchaseServiceInfo.TotalDiscount;
                    purchaseStoreInfo.TotalAmount = purchaseServiceInfo.TotalAmount;
                    purchaseStoreInfo.PurchasedDate = purchaseServiceInfo.PurchasedDate;
                    purchaseStoreInfo.CreatedBy = purchaseServiceInfo.CreatedBy;
                    purchaseStoreInfo.ModifiedBy = purchaseServiceInfo.ModifiedBy;
                    purchaseStoreInfo.CreatedDate = purchaseServiceInfo.CreatedDate;
                    purchaseStoreInfo.ModifiedDate = purchaseServiceInfo.ModifiedDate;

                    _purchaseStore.AddPurchase(purchaseStoreInfo);
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






        public void UpdatePurchase(PurchaseServiceInfo purchaseServiceInfo)
        {
            var purchaseStoreInfo = new PurchaseStoreInfo();
            purchaseStoreInfo.PurchaseID = purchaseServiceInfo.PurchaseID;
            purchaseStoreInfo.ProductID = purchaseServiceInfo.ProductID;
            purchaseStoreInfo.Quantity = purchaseServiceInfo.Quantity;
            purchaseStoreInfo.UnitPrice = purchaseServiceInfo.UnitPrice;
            purchaseStoreInfo.UnitDiscount = purchaseServiceInfo.UnitDiscount;
            purchaseStoreInfo.TotalDiscount = purchaseServiceInfo.TotalDiscount;
            purchaseStoreInfo.TotalAmount = purchaseServiceInfo.TotalAmount;
            purchaseStoreInfo.PurchasedDate = purchaseServiceInfo.PurchasedDate;
            purchaseStoreInfo.CreatedBy = purchaseServiceInfo.CreatedBy;
            purchaseStoreInfo.ModifiedBy = purchaseServiceInfo.ModifiedBy;
            purchaseStoreInfo.CreatedDate = purchaseServiceInfo.CreatedDate;
            purchaseStoreInfo.ModifiedDate = purchaseServiceInfo.ModifiedDate;

            _purchaseStore.UpdatePurchase(purchaseStoreInfo);
        }

        public void DeletePurchase(long PurchaseID)
        {
            _purchaseStore.DeletePurchase(PurchaseID);
        }

        private ArrayList ValidatePurchase(PurchaseServiceInfo purchaseServiceInfo)
        {
            ArrayList list = new ArrayList();

            if (purchaseServiceInfo.ProductID <= 0)
            {
                list.Add("ProductId Does Not Exists");
            }
            if (purchaseServiceInfo.Quantity <= 0)
            {
                list.Add("Purchase Quantity Does Not Exists");
            }
            if (string.IsNullOrEmpty(purchaseServiceInfo.CreatedBy))
            {
                list.Add(" Purchase CreatedBy Does Not Exists");
            }

            return list;
        }

        private ArrayList IsPurchaseExist(long productID, int quantity)
        {
            ArrayList list = new ArrayList();
            var purchase = _purchaseStore.GetPurchase();
            var result = purchase.Any(p => p.ProductID == productID);
            if (result)
            {
                list.Add("ProductId Already Exists");
            }
            //var purchase1 = _purchaseStore.GetPurchase();
            //var result1 = purchase.Any(q => q.Quantity > quantity);
            //if (result1)
            //{
            //    list.Add("Quantity is Greater than Purchased Quantity");
            //}
            return list;
        }
    }
}
