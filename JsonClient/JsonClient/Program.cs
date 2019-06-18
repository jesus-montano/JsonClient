using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace JsonClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await runClient();
        }
        static async Task runClient(){
            Comment comment;
            Client client = new Client();
            int option = 0;
             var commentController = new CommentController(); 

               while(option < 5){
                Console.WriteLine("Select an option:\n 1 Get all\n 2 GetById\n 3 Create new Comment\n 4 Update Comment\n 5 exit");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                       List<Comment> comments = await commentController.GetAll(client);
                       foreach(Comment comm in comments){
                            Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comm.name, comm.email, comm.body);
                        }
                        break;
                    case 2:
                        comment = await commentController.GetById(client, GetId());
                        Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
                        break;
                    case 3:
                       comment = await commentController.postComment(client, GetComment());
                       Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
                        break;
                    case 4:
                       comment = await commentController.updateComment(client, GetId(), GetComment());
                       Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
                        break;        
                    default:
                        Console.WriteLine("Default case");
                        break;
                }

               }

        }

        public static Comment GetComment(){
            string name, email, body;
            
            Console.WriteLine("write name ");
            name = Console.ReadLine();
            Console.WriteLine("write email ");
            email = Console.ReadLine();
            Console.WriteLine("write body ");
            body = Console.ReadLine();
            
            return new Comment(name, email, body);
        }

        public static string GetId(){
            string id;
            Console.WriteLine("Write id");
            id = Console.ReadLine();

            return id;
        }
        
    }

}
   
