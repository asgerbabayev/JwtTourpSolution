using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.Utilities.Results;
using TourP.Entities.Concrete;
using TourP.Entities.DTOs.AdsDTO;

namespace TourP.Business.Abstract
{
    public interface IAdsService
    {
        IDataResult<List<Ads>> GetAll();
        IDataResult<Ads> GetById(int id);
        IResult Add(Ads ads);
        IResult Update(Ads ads);
        IResult Delete(Ads ads);
    }
}
