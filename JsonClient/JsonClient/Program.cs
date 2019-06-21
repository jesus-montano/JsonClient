using System;
using System.Threading.Tasks;

namespace JsonClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
          // await runClient();
          await GetObject(new Comment());

        }
        static async Task runClient(){
            
            
            int option = 0;
             while(option < 6){
                Console.WriteLine("Select an option:\n 1 Comments\n 2 Post\n 3 Create new Comment\n 4 Update Comment\n 5 exit");
                option = Int32.Parse(Console.ReadLine());
                

                switch (option)
                {
                    case 1:
                       await Crudmenu<Comment>();
                        break;
                }
             }

               

        }
        static async  Task Crudmenu<TObject>(){
            var client = new JsonClient<TObject>();
            int option = 0;
            var comment =default(TObject);
            while(option < 5){
                Console.WriteLine("Select an option:\n"+ 
                "1 Get all\n 2 GetById\n 3 Create new Comment\n 4 Update Comment\n 5 exit");
                option = Int32.Parse(Console.ReadLine());
                

                switch (option)
                {
                    case 1:
                       var comments = await client.GetAsync();
                       if(comments != null)
                       {
                        foreach(TObject comm in comments){
                               // Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}\n", comm.name, comm.email, comm.body);
                            }
                       }else
                       {
                           Console.ForegroundColor = ConsoleColor.Red;
                           Console.WriteLine("not found");
                           Console.ResetColor();
                       }
                        break;
                    case 2:
                        comment = await client.GetAsync(GetId());
                        if(comment != null){
                        //Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
                        }else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("not found");
                            Console.ResetColor();
                        }

                        break;
                    case 3:
                       //comment = await client.PostAsync( GetComment());
                       if(comment != null){
                       //Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
                       }else
                       {
                          Console.ForegroundColor = ConsoleColor.Red;
                          Console.WriteLine("error while Saved");
                          Console.ResetColor();
                       }
                        break;
                    case 4:
                       //comment = await client.UpdateAsync( GetId(), GetComment());
                       if(comment != null){
                       //Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
                       }else
                       {
                          Console.ForegroundColor = ConsoleColor.Red;
                          Console.WriteLine("error while updated");
                          Console.ResetColor();
                       }
                        break;        
                    default:
                        Console.WriteLine("Default case");
                        break;
                }

               }
        }

        public static async  Task<object> GetObject(object obj){
            
            Type t = obj.GetType();
            var nameObj = t.Name;
            //string name, email, body,title, url,thumbnailUrl;
            // int userId,albumId;
           switch(nameObj){
            case "Comment":
                var properties =t.GetProperties();
                foreach(var pi in properties){
                    var propertyName = pi.Name;
                    Console.WriteLine($"write {propertyName}");
                    var propertyValue = Console.ReadLine();
                    var pit = pi.PropertyType;
                    if (pit == typeof(int)){
                      pi.SetValue(null,Int32.Parse(propertyValue));
                    }else{
                        pi.SetValue(null,propertyValue);
                    }    
                }
                break;
            
            // case "Post":
            //     Console.WriteLine("write UserId ");
            //     userId = Int32.Parse(Console.ReadLine());
            //     Console.WriteLine("write title ");
            //     title = Console.ReadLine();
            //     Console.WriteLine("write body ");
            //     body = Console.ReadLine();
                
            //     break;
            //  case "Photo":
            //     Console.WriteLine("write AlbumId ");
            //     albumId = Int32.Parse(Console.ReadLine());
            //     Console.WriteLine("write title ");
            //     title = Console.ReadLine();
            //     Console.WriteLine("write Url ");
            //     url = Console.ReadLine();
            //     Console.WriteLine("write thumbnailUrl ");
            //     thumbnailUrl = Console.ReadLine();
                
            //     break;
            // case "Album":
            //     Console.WriteLine("write UserId ");
            //     userId = Int32.Parse(Console.ReadLine());
            //     Console.WriteLine("write title ");
            //     title = Console.ReadLine();
                
            //     break;    
            default:
                break;
           }

            
            return null;
        }

        public static string GetId(){
            string id;
            Console.WriteLine("Write id");
            id = Console.ReadLine();

            return id;
        }
        
    }

}
   
