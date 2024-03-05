using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFileHelper = Core.Utilities.Helpers.FileHelper.IFileHelper;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService

    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {

            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));//mevcut iş kuralı varsa onu çalıştırır.
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file, PathConstans.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("image uploaded successfully :)");
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstans.ImagesPath + carImage.ImagePath);
            //pathconstants.ImagePath ifadesi, resim dosyalarının bulunduğu dosya yolunu temsil eder
            //carimage.ımagepath ise silinecek resim dosyasının yolunu içerir. Bu iki ifade birleştirilerek silinecek resim dosyasının tam yolu elde edilir
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.EntitiesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                //eğer araba resmi varsa hata
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            //eger araba resmi yoksa default resmi getiriyor
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == carId), Messages.EntityDetailsListed);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstans.ImagesPath + carImage.ImagePath, PathConstans.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "DefaultImage.jpg"
            });

            return new SuccessDataResult<List<CarImage>>(carImage);
        }
        private IResult CheckIfCarImageLimit(int carId)
        {
            //maximum resim boyutunu kontrol ediyor. eğer bir arabanın 5 den fazla resmi varsa error
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

