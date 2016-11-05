using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.Models.Interfaces;
using Example_04.Homework.SecondOrmLibrary;


namespace Example_04.Homework
{
    public class Test
    {
        public void CheckWork()
        {
            ISecondOrm second = null;
            IFirstOrm<IDbEntity> first = new Adapter<IDbEntity>(second);

            var entityUser = new DbUserEntity();
            var entityUserInfo = new DbUserInfoEntity();

            first.Create(entityUser);
            first.Create(entityUserInfo);
        }


    }
}