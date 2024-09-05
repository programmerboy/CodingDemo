namespace ServerSide.Services
{
    public interface IDataService
    {
        Task<InitializeModel> Initialize(int size);
        Task<RowModel> GetNumbers(string dataset, string type, int idx);
        Task<int[,]> LoadMatrix(string dataset, int size);
        Task<ValidateModel> Validate(int[,] matrix);
        Task Foo(int num);
        int[,] Concatenate(int[,] arrayA, int[,] arrayB);
    }
}
