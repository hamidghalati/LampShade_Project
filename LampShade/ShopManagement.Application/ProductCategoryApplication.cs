﻿using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            ////در صورت رکورد تکراری
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
                return operation.Failed("این نام از قبل وجود دارد، نام جدیدی انتخاب کنید");
            ////عملیات ایجاد
            var slug = command.Slug.Slugify();
            var productCategory = new ProductCategory(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            _productCategoryRepository.Create(productCategory);


            _productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return operation.Failed("چنین رکوردی وجود ندارد");


            if (_productCategoryRepository.Exists(x=>x.Name==command.Name && x.Id !=command.Id))
                return operation.Failed("این نام از قبل وجود دارد، نام جدیدی انتخاب کنید");


            var slug = command.Slug.Slugify();
            productCategory.Edit(command.Name,command.Description,command.Picture,
                command.PictureAlt,command.PictureTitle,command.Keywords,command.MetaDescription,slug);
            _productCategoryRepository.SaveChanges();
            return operation.Succeeded("اطلاعات شما با موفقیت ویرایش شد");
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}