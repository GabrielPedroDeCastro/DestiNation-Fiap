using DestiNation.Models;
using DestiNation.Repository.Context;

namespace DestiNation.Repository
{
    public class PassportRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public PassportRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<PassportModel> Listar()
        {
            var lista = new List<PassportModel>();
            lista = dataBaseContext.Passport.ToList<PassportModel>();
            return lista;
        }
        public PassportModel Consultar(int id)
        {
            var passport = dataBaseContext.Passport.Find(id);

            return passport;
        }

        public void Inserir(PassportModel passport)
        {
            dataBaseContext.Passport.Add(passport);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(PassportModel passport)
        {
            dataBaseContext.Passport.Update(passport);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(PassportModel passport)
        {
            //var passport = new PassportModel(id, "");

            dataBaseContext.Passport.Remove(passport);
            dataBaseContext.SaveChanges();
        }

    }
}
