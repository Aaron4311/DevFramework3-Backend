using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;

namespace DevFramework.Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]
        public void Get_all_returns_50_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetAll().Count;
            Assert.AreEqual(50, result);
        }

		[TestMethod]
		public void Get_all_returns_all_filtered_products()
		{
			EfProductDal productDal = new EfProductDal();

			var result = productDal.GetAll(p => p.ProductName.Contains("ab")).Count;
			Assert.AreEqual(4, result);
		}
		[TestMethod]
		public void Get_product_details_returns_all_product_details()
		{
			EfProductDal productDal = new EfProductDal();

			var result = productDal.GetProductDetails().Count;
			Assert.AreEqual(101, result);
		}

	}
}