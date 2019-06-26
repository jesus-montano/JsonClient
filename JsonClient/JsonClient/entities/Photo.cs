public class Photo{
    public Photo(){}
    public Photo(int AlbumId,int Id,string Title, string Url, string ThumbnailUrl ){
        this.AlbumId = AlbumId;
        this.Id =Id;
        this.Title = Title;
        this.Url = Url;
        this.ThumbnailUrl =ThumbnailUrl;
    }
    public int AlbumId;
    public int Id;    
    public string Title;
    public string Url;
    public string ThumbnailUrl;
}