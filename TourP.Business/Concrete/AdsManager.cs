using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Business.Abstract;
using TourP.Business.Constants;
using TourP.Core.Utilities.Results;
using TourP.DataAccess.Abstract;
using TourP.Entities.Concrete;
using TourP.Entities.DTOs.AdsDTO;

namespace TourP.Business.Concrete
{
    public class AdsManager : IAdsService
    {
        private readonly IAdsDal _adsDal;

        public AdsManager(IAdsDal adsDal)
        {
            _adsDal = adsDal;
        }

        public IResult Add(Ads ads)
        {
            _adsDal.Add(ads);
            return new SuccessResult(Messages.AdsAdded);
        }

        public IResult Delete(Ads ads)
        {
            _adsDal.Delete(ads);
            return new SuccessResult(Messages.AdsDeleted);
        }

        public IDataResult<List<Ads>> GetAll()
        {
            var adsList=_adsDal.GetAll();
            return new SuccessDataResult<List<Ads>>(adsList);
        }

        public IDataResult<Ads> GetById(int id)
        {
            return new SuccessDataResult<Ads>(_adsDal.Get(a => a.Id == id));
        }

        public IResult Update(Ads ads)
        {
            _adsDal.Update(ads);
            return new SuccessResult();
        }
    }
}
