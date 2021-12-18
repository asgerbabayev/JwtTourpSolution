using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.Utilities.Results;
using TourP.Entities.Concrete;

namespace TourP.Business.Abstract
{
    public interface IStepService
    {
        IDataResult<List<Steps>> GetAll();
        IDataResult<Steps> GetById(int id);
        IResult Add(Steps steps);
        IResult Update(Steps steps);
        IResult Delete(Steps steps);
    }
}
