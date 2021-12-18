using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Business.Abstract;
using TourP.Core.Utilities.Results;
using TourP.DataAccess.Abstract;
using TourP.Entities.Concrete;

namespace TourP.Business.Concrete
{
    public class StepManager : IStepService
    {
        private readonly IStepDal _stepDal;

        public StepManager(IStepDal stepDal)
        {
            _stepDal = stepDal;
        }

        public IResult Add(Steps steps)
        {
            _stepDal.Add(steps);
            return new SuccessResult();
        }

        public IResult Delete(Steps steps)
        {
            _stepDal.Delete(steps);
            return new SuccessResult();
        }

        public IDataResult<List<Steps>> GetAll()
        {
            var stepList = _stepDal.GetAll();
            return new SuccessDataResult<List<Steps>>(stepList);
        }

        public IDataResult<Steps> GetById(int id)
        {
            return new SuccessDataResult<Steps>(_stepDal.Get(s => s.Id == id));
        }

        public IResult Update(Steps steps)
        {
            _stepDal.Update(steps);
            return new SuccessResult();
        }
    }
}
