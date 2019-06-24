public class Photo{
    public Photo(){}
    public Photo(int albumId,int id,string title, string url, string thumbnailUrl ){
        this.albumId = albumId;
        this.id =id;
        this.title = title;
        this.url = url;
        this.thumbnailUrl =thumbnailUrl;
    }
    public int albumId;
    public int id;    
    public string title;
    public string url;
    public string thumbnailUrl;
}