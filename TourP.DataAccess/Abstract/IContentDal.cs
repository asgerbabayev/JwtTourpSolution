using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.DataAccess;
using TourP.Entities.Concrete;

namespace TourP.DataAccess.Abstract
{
    public interface IContentDal:IEntityRepository<Content>
    {
    }
}
