using static System.Runtime.InteropServices.JavaScript.JSType;

namespace testAPI.Models
{
    public class APIModel
    {
        public int Status { get; set; }
        public object Errors { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public List<DataDetial> data { get; set; }
    }

    public class DataDetial
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int Comment { get; set; }
        public int Share { get; set; }
        public int Play { get; set; }
        public int DouyinTargetId { get; set; }
        public string Url { get; set; }
        public DateTime CreationTime { get; set; }
        public string Type { get; set; }
        public List<Image> Images { get; set; }
        public List<Video> Videos { get; set; }
        public DouyinTarget DouyinTarget { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ImageableType { get; set; }
        public bool Downloaded { get; set; }
        public int ImageableId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string VideoableType { get; set; }
        public bool Downloaded { get; set; }
        public int VideoableId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class DouyinTarget
    {
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }
}
