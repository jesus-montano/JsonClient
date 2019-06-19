using System;
using System.Threading.Tasks;

namespace JsonClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await runClient();
        }
        static async Task runClient(){
            var comment =default(Comment);
            var client = new JsonClient<Comment>();
            int option = 0;

               while(option < 5){
                Console.WriteLine("Select an option:\n 1 Get all\n 2 GetById\n 3 Create new Comment\n 4 Update Comment\n 5 exit");
                option = Int32.Parse(Console.ReadLine());
                

                switch (option)
                {
                    case 1:
                       var comments = await client.GetAsync();
                       if(comments != null)
                       {
                        foreach(Comment comm in comments){
                                Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}\n", comm.name, comm.email, comm.body);
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
                        Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
                        }else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("not found");
                            Console.ResetColor();
                        }

                        break;
                    case 3:
                       comment = await client.PostAsync( GetComment());
                       if(comment != null){
                       Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
                       }else
                       {
                          Console.ForegroundColor = ConsoleColor.Red;
                          Console.WriteLine("error while Saved");
                          Console.ResetColor();
                       }
                        break;
                    case 4:
                       comment = await client.UpdateAsync( GetId(), GetComment());
                       if(comment != null){
                       Console.WriteLine("name: {0}\nemail: {1}\nbody: {2}", comment.name, comment.email, comment.body);
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
   
