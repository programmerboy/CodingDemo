namespace ServerSide
{
    public class ResponseModel
    {
        public string Cause { get; set; }
        public bool Success { get; set; }
    }

    public class InitializeModel : ResponseModel
    {
        public int Value { get; set; }
    }

    public class RowModel : ResponseModel
    {
        public int[] Value { get; set; }
    }

    public class ValidateModel : ResponseModel
    {
        public string Value { get; set; }
    }
}
