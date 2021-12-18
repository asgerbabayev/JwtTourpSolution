using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.Utilities.Results;
using TourP.Entities.Concrete;

namespace TourP.Business.Abstract
{
    public interface IEntryService
    {
        IDataResult<List<Entry>> GetAll();
        IDataResult<Entry> GetById(int id);
        IResult Add(Entry entry);
        IResult Update(Entry entry);
        IResult Delete(Entry entry);
    }
}
