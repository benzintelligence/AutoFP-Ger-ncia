namespace AutoFP.Gerencia.Application.Interface.Base
{
    public interface IBaseAppService
    {
        void BeginTransaction();

        void Commit();
    }
}