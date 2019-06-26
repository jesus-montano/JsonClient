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
            
            
            int option = 0;
             while(option < 7){
                Console.WriteLine("Select an entity option:\n1 Comments\n2 Post\n3 Album\n4 Photo\n5 Todo\n6 User\n7 exit");
                option = Int32.Parse(Console.ReadLine());
                

                switch (option)
                {
                    case 1:
                       await Crudmenu<Comment>(new Comment());
                        break;
                    case 2:
                       await Crudmenu<Post>(new Post());
                        break;
                    case 3:
                       await Crudmenu<Album>(new Album());
                        break;
                    case 4:
                       await Crudmenu<Photo>(new Photo());
                        break;
                    case 5:
                       await Crudmenu<Todo>(new Todo());
                        break;
                    case 6:
                      await Crudmenu<User>(new User());
                        break;
                    case 7:
                        Console.WriteLine("bye");
                        break;        
                }
             }

               

        }
        static async  Task Crudmenu<TObject>(TObject obj){
            var client = new JsonClient<TObject>();
            int option = 0;
            var result =default(TObject);
            
            while(option < 4){
                Console.WriteLine("Select an CRUD option:\n"+ 
                "1 Get all\n2 GetById\n3 Create new\n4 Update\n5 exit");
                option = Int32.Parse(Console.ReadLine());
                

                switch (option)
                {
                    case 1:
                       var results = await client.GetAsync();
                       if(results != null)
                       {
                        foreach(TObject res in results){
                               PrintObject(res);
                            }
                       }else
                       {
                           Console.ForegroundColor = ConsoleColor.Red;
                           Console.WriteLine("not found");
                           Console.ResetColor();
                       }
                        break;
                    case 2:
                        result = await client.GetAsync(GetId());
                        if(result != null){
                            PrintObject(result);
                        }else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("not found");
                            Console.ResetColor();
                        }

                        break;
                    case 3:
                       result = await client.PostAsync( GetObject<TObject>(obj));
                       if(result != null){
                           PrintObject(result);
                       }else
                       {
                          Console.ForegroundColor = ConsoleColor.Red;
                          Console.WriteLine("error while Saved");
                          Console.ResetColor();
                       }
                        break;
                    case 4:
                       result = await client.UpdateAsync( GetId(), GetObject<TObject>(obj));
                       if(result != null){
                           PrintObject(result);
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
                break;

               }
        }

        public static void PrintObject(object obj){
                Type t = obj.GetType();
                var properties =t.GetProperties();
                foreach(var pi in properties){
                    if(Attribute.IsDefined(pi,typeof(IsClass))){
                      PrintObject(pi.GetValue(obj));
                    }else{
                        var propertyName = pi.Name;
                        var propertyValue = pi.GetValue(obj);
                        Console.WriteLine($"{propertyName}: {propertyValue}\n");
                    }
                }
        } 
        public static TObject GetObject<TObject>(TObject obj){
            
            Type t = obj.GetType();
                var properties =t.GetProperties();
                foreach(var pi in properties){
                    if(!Attribute.IsDefined(pi,typeof(Skip))){
                        if(Attribute.IsDefined(pi,typeof(IsClass))){
                        var instanceComplexObj = Activator.CreateInstance(pi.PropertyType);
                        var complexObj = GetObject(instanceComplexObj);
                        pi.SetValue(obj,complexObj);
                        }else{
                            var propertyName = pi.Name;
                            Console.WriteLine($"write {propertyName}");
                            var propertyValue = Console.ReadLine();
                            var pit = pi.PropertyType;
                            if (pit == typeof(int)){
                            pi.SetValue(obj,Int32.Parse(propertyValue));
                            }else if(pit == typeof(decimal)){
                                pi.SetValue(obj,Decimal.Parse(propertyValue));
                            }else{
                                pi.SetValue(obj, propertyValue);
                            }
                        }
                    }
                }
            return obj;
        }
        public static string GetId(){
            string id;
            Console.WriteLine("Write id");
            id = Console.ReadLine();

            return id;
        }
        
    }

}
   
