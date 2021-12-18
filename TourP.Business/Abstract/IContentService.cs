using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.Utilities.Results;
using TourP.Entities.Concrete;

namespace TourP.Business.Abstract
{
    public interface IContentService
    {
        IDataResult<List<Content>> GetAll();
        IDataResult<Content> GetById(int id);
        IResult Add(Content content);
        IResult Update(Content content);
        IResult Delete(Content content);
    }
}
