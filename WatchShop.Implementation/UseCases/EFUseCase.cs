using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases
{
    public abstract class EFUseCase
    {
        private readonly AspContext _context;

        protected EFUseCase(AspContext context)
        {
            _context = context;

        }
        protected AspContext Context => _context;
    }
}
