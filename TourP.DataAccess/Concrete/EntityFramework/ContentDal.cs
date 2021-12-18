using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.DataAccess.EntityFramework;
using TourP.DataAccess.Abstract;
using TourP.Entities.Concrete;

namespace TourP.DataAccess.Concrete.EntityFramework
{
    public class ContentDal:EfCoreRepositoryBase<Content,EfCoreDbContext>,IContentDal
    {
    }
}
