using JsonClient.Attributes;
namespace JsonClient.Entities
{
    
    public class Photo : AbstractManageObject
    {

        [Skip]
        public int AlbumId {get; set;}

        [Skip]
        public int Id {get; set;}    

        public string Title {get; set;}

        public string Url {get; set;}

        public string ThumbnailUrl {get; set;}
        
        public Photo(){ }
        
        public Photo(int AlbumId,int Id,string Title, string Url, string ThumbnailUrl ){
            this.AlbumId = AlbumId;
            this.Id =Id;
            this.Title = Title;
            this.Url = Url;
            this.ThumbnailUrl =ThumbnailUrl;
        }
    }
}
