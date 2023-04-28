using DestiNation.Models;
using DestiNation.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DestiNation.Repository
{
    public class CountryRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CountryRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<CountryModel> Listar()
        {
            var lista = new List<CountryModel>();
            lista = dataBaseContext.Country.ToList<CountryModel>();
            return lista;
        }

        public CountryModel Consultar(int id)
        {
            var country = dataBaseContext.Country.Find(id);

            return country;
        }

        public void Inserir(CountryModel country)
        {
            dataBaseContext.Country.Add(country);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(CountryModel country)
        {
            dataBaseContext.Country.Update(country);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(CountryModel country)
        {
            //var country = new CountryModel(id,"");

            dataBaseContext.Country.Remove(country);
            dataBaseContext.SaveChanges();
        }



    }
}
