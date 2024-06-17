using AspProjekat2024.Application.DTO;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfDeleteModelCommand : EfUseCase, IDeleteModelCommand
    {
        public EfDeleteModelCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 29;

        public string Name => "Delete Model";

        public string Description => "Delete Model";

        public void Execute(DeleteDto request)
        {
            var model = Context.Models.Find(request.Id);

            Context.Models.Remove(model);

            Context.SaveChanges();
            
        }

    }
}
