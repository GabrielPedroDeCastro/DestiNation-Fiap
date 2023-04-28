using DestiNation.Models;
using DestiNation.Repository.Context;

namespace DestiNation.Repository
{
    public class UserRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public UserRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<UserModel> Listar()
        {
            var lista = new List<UserModel>();
            lista = dataBaseContext.User.ToList<UserModel>();
            return lista;
        }
        public UserModel Consultar(int id)
        {
            var user = dataBaseContext.User.Find(id);

            return user;
        }

        public void Inserir(UserModel user)
        {
            dataBaseContext.User.Add(user);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(UserModel user)
        {
            dataBaseContext.User.Update(user);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(UserModel user)
        {
            //var user = new UserModel(id, "");

            dataBaseContext.User.Remove(user);
            dataBaseContext.SaveChanges();
        }
    }
}
