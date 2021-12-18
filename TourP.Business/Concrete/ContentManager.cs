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

namespace TourP.Business.Concrete
{
    public class ContentManager:IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public IResult Add(Content content)
        {
            _contentDal.Add(content);
            return new SuccessResult(Messages.ContentAdded);
        }

        public IResult Delete(Content content)
        {
            _contentDal.Delete(content);
            return new SuccessResult();
        }

        public IDataResult<List<Content>> GetAll()
        {
            var adsList = _contentDal.GetAll();
            return new SuccessDataResult<List<Content>>(adsList);
        }

        public IDataResult<Content> GetById(int id)
        {
            return new SuccessDataResult<Content>(_contentDal.Get(a => a.Id == id));
        }

        public IResult Update(Content content)
        {
            _contentDal.Update(content);
            return new SuccessResult();
        }
    }
}
