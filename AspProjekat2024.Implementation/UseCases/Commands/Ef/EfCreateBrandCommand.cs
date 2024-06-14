using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfCreateBrandCommand : EfUseCase, ICreateBrandCommand
    {
        public EfCreateBrandCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Create Brand";

        public string Description => "Create new brand";

        public void Execute(CreateBrandDto request)
        {
            Context.Brands.Add(new Domain.Brand
            {
                Name = request.Name
            });
            Context.SaveChanges();

            
        }
    }
}
