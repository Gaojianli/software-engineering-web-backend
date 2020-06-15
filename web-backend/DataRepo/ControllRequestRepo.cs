using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using web_backend.Model;

namespace web_backend.DataRepo
{
    public class ControllRequestRepo:BaseRepo<ControllRequestRepo>
    {
        public ControllRequest Add(ControllRequest toAdd)
        {
            dbContext.ControllRequest.Add(toAdd);
            return toAdd;
        }

        public ControllRequest findByID(int id) => dbContext.ControllRequest.Find(id);

        public IEnumerable<ControllRequest> Fetch(Expression<Func<ControllRequest, bool>> predicate) => dbContext.ControllRequest.Where(predicate).ToList();
    }
}
