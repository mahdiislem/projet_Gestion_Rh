namespace projet_Gestion_Rh.Models
{
    public interface IFormatFile
    {
        int length { get; }
        string FileName { get; }

        void CopyTo(FileStream fileStream);
        Task CopyToAsync(FileStream fileStream);
    }
}