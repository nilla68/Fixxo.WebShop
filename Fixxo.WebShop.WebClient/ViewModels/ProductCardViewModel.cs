using Fixxo.WebShop.DomainModel;

namespace Fixxo.WebShop.WebClient.ViewModels
{
    /// <summary>
    /// Design Decision: This class is the ViewModel for the ProductCard Component according to the MVVM pattern.
    /// </summary>
    public class ProductCardViewModel
    {
        private readonly ProductModel _productModel;

        public ProductCardViewModel(ProductModel productModel)
        {
            _productModel = productModel;
        }

        public Guid Id
        {
            get { return _productModel.Id; }
            set { _productModel.Id = value; }
        }

        public string Name
        {
            get { return _productModel.Name; }
            set { _productModel.Name = value; }
        }

        public string Sku
        {
            get { return _productModel.Sku; }
            set { _productModel.Sku = value; }
        }

        public string Brand
        {
            get { return _productModel.Brand; }
            set { _productModel.Brand = value; }
        }

        public int Rating
        {
            get { return _productModel.Rating; }
            set { _productModel.Rating = value; }
        }

        public decimal Price
        {
            get { return _productModel.Price; }
            set { _productModel.Price = value; }
        }

        public string Description
        {
            get { return _productModel.Description; }
            set { _productModel.Description = value; }
        }

        public string Size
        {
            get { return _productModel.Size; }
            set { _productModel.Size = value; }
        }

        public string Color
        {
            get { return _productModel.Color; }
            set { _productModel.Color = value; }
        }

        public string Image
        {
            get { return _productModel.Image; }
            set { _productModel.Image = value; }
        }

        public CategoryModel Category
        {
            get { return _productModel.Category; }
            set { _productModel.Category = value; }
        }
    }
}


