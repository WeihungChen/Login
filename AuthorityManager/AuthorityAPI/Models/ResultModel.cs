namespace AuthorityAPI.Models
{
    public class ResultModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}