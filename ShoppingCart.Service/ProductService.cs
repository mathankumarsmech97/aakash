

using Sample.Shopping.Store.productStore;
using ShoppingCart.Store;
using System.Collections;

namespace productService
{
    public interface IProductService
    {
        List<ProductServiceInfo> GetProducts();
        ArrayList AddProduct(ProductServiceInfo productServiceInfo);

        ProductServiceInfo GetProduct(long ProductId);

        ArrayList UpdateProduct(ProductServiceInfo productServiceInfo);

        void DeleteProduct(long ProductId);

    }

    public class ProductService : IProductService
    {
        private readonly IProductStore _ProductStore;

        public ProductService(IProductStore ProductStore)
        {
            _ProductStore = ProductStore;
        }
        public List<ProductServiceInfo> GetProducts()
        {
            var productStoreInfoList = _ProductStore.GetProducts();
            //var products = new List<ProductStoreInfo>();
            if (productStoreInfoList == null)
            {
                return null;
            }
            else
            {
                var productServiceInfoList = new List<ProductServiceInfo>();
                foreach (var productStoreInfo in productStoreInfoList)
                {
                    //var productServiceInfo = new ProductServiceInfo();
                    //productServiceInfo.ProductId = productStoreInfo.ProductId;

                    productServiceInfoList.Add(new ProductServiceInfo
                    {
                        ProductId = productStoreInfo.ProductId,
                        ProductName = productStoreInfo.ProductName,
                        UnitPrice = productStoreInfo.UnitPrice,
                        UnitDiscount = productStoreInfo.UnitDiscount,
                        CreatedBy = productStoreInfo.CreatedBy,
                        ModifiedBy = productStoreInfo.ModifiedBy,
                        CreatedDate = productStoreInfo.CreatedDate,
                        ModifiedDate = productStoreInfo.ModifiedDate
                    });

                    //Automapper.map()
                }
                return productServiceInfoList;
            }
        }
        public ProductServiceInfo GetProduct(long ProductId)
        {
            var productStoreinfo = _ProductStore.GetProduct(ProductId);
            if (productStoreinfo == null)
            {
                return null;
            }
            else
            {
                return new ProductServiceInfo
                {
                    ProductId = productStoreinfo.ProductId,
                    ProductName = productStoreinfo.ProductName,
                    UnitPrice = productStoreinfo.UnitPrice,
                    UnitDiscount = productStoreinfo.UnitDiscount,
                    CreatedBy = productStoreinfo.CreatedBy,
                    ModifiedBy = productStoreinfo.ModifiedBy,
                    CreatedDate = productStoreinfo.CreatedDate,
                    ModifiedDate = productStoreinfo.ModifiedDate
                };
            }
        }
        public ArrayList AddProduct(ProductServiceInfo productServiceInfo)
        {
            //Check IsValidProduct
            //var Product = IsValidProductName(productServiceInfo);
            //if (Product != "Product Required")
            //{
            //    return Product;
            //}
            ////if (isProdExist == true)
            ////{
            ////    return "ProductName Already Exists";
            ////}
            ////Check Product already exist
            //var isProdExist = IsProductExist(productServiceInfo.ProductName);
            //if (isProdExist == true)
            //{
            //    return "ProductName Already Exists";
            //}
            //var Product = Validate(productServiceInfo);
            //if(Product != list)
            var valid = Validate(productServiceInfo);
            if (valid.Count == 0)
            {
                var exist = IsProductExist(productServiceInfo.ProductName);
                if (exist.Count == 0)
                {
                    var productstoreinfo = new ProductStoreInfo();
                    productstoreinfo.ProductId = productServiceInfo.ProductId;
                    productstoreinfo.ProductName = productServiceInfo.ProductName;
                    productstoreinfo.UnitPrice = productServiceInfo.UnitPrice;
                    productstoreinfo.UnitDiscount = productServiceInfo.UnitDiscount;
                    productstoreinfo.CreatedBy = productServiceInfo.CreatedBy;
                    productstoreinfo.ModifiedBy = productServiceInfo.ModifiedBy;
                    productstoreinfo.CreatedDate = productServiceInfo.CreatedDate;
                    productstoreinfo.ModifiedDate = productServiceInfo.ModifiedDate;
                    _ProductStore.AddProduct(productstoreinfo);
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

            // return productstoreinfo.ProductName;
            //return result.ToString();
            //return  ;
        }

        public ArrayList UpdateProduct(ProductServiceInfo productServiceInfo)

        {
            var valid = Validate(productServiceInfo);
            if (valid.Count == 0)
            {

                var productstoreinfo = new ProductStoreInfo();
                productstoreinfo.ProductId = productServiceInfo.ProductId;
                productstoreinfo.ProductName = productServiceInfo.ProductName;
                productstoreinfo.UnitPrice = productServiceInfo.UnitPrice;
                productstoreinfo.UnitDiscount = productServiceInfo.UnitDiscount;
                productstoreinfo.CreatedBy = productServiceInfo.CreatedBy;
                productstoreinfo.ModifiedBy = productServiceInfo.ModifiedBy;
                productstoreinfo.CreatedDate = DateTime.UtcNow;
                productstoreinfo.ModifiedDate = productServiceInfo.ModifiedDate;
                _ProductStore.UpdateProduct(productstoreinfo);
            }
            else
            {
                return valid;
            }
            return valid;
        }

        public void DeleteProduct(long ProductId)
        {
            _ProductStore.DeleteProduct(ProductId);
        }

        private ArrayList Validate(ProductServiceInfo productServiceInfo)
        {
            ArrayList list = new ArrayList();
            if (string.IsNullOrEmpty(productServiceInfo.ProductName))
            {
                list.Add("ProductName is Empty");
            }

            if (productServiceInfo.UnitPrice <= 0)
            {
                list.Add("Enter Valid UnitPrice");
            }
            if (productServiceInfo.UnitDiscount <= 0)
            {
                list.Add("Enter Valid UnitDiscount");
            }
            if (string.IsNullOrEmpty(productServiceInfo.CreatedBy))
            {
                list.Add("CreatedBy is Empty");
            }
            if (string.IsNullOrEmpty(productServiceInfo.ModifiedBy))
            {
                list.Add("ModifiedBy is Empty");
            }
            return list;
        }

        private ArrayList IsProductExist(string productName)
        {
            var arraylist = new ArrayList();

            var products = _ProductStore.GetProducts();
            var result = products.Any(p => productName.Contains(p.ProductName));
            if (result)
            {
                arraylist.Add("ProductName Already Exists");
            }
            return arraylist;
        }
    }
}
