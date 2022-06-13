namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public string Picture { get; set; }
        public string DateCreate { get; set; }
        public long ProductId { get; set; }
    }
}