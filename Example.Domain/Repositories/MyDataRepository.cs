using System;

namespace Example.Domain.Repositories
{
    public interface IMyDataRepository
    {
        void GetMyData();
    }


    internal class MyDataRepository : IMyDataRepository
    {
        public void GetMyData()
        {
            throw new NotImplementedException();
        }
    }
}
