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
    public class EntryManager : IEntryService
    {
        private readonly IEntryDal _entryDal;

        public EntryManager(IEntryDal entryDal)
        {
            _entryDal = entryDal;
        }

        public IResult Add(Entry entry)
        {
            _entryDal.Add(entry);
            return new SuccessResult();
        }

        public IResult Delete(Entry entry)
        {
            _entryDal.Delete(entry);
            return new SuccessResult();
        }

        public IDataResult<List<Entry>> GetAll()
        {
            var entryList = _entryDal.GetAll();
            return new SuccessDataResult<List<Entry>>(entryList);
        }

        public IDataResult<Entry> GetById(int id)
        {
            return new SuccessDataResult<Entry>(_entryDal.Get(a => a.Id == id));
        }

        public IResult Update(Entry entry)
        {
            _entryDal.Update(entry);
            return new SuccessResult();
        }
    }
}
