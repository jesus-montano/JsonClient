using System;
using System.Threading.Tasks;
using JsonClient.Entities;
using JsonClient.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Reflection;
namespace JsonClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await runClient();

        }

        static async Task runClient()
        {
            
            
            int option = 0;
             while(option < 7)
             {
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
        static async  Task Crudmenu<TObject>(TObject obj)
        {
            var client = new JsonClient<TObject>();
            int option = 0;
            var result =default(TObject);
            
            while(option < 4)
            {
                Console.WriteLine("Select an CRUD option:\n"+ 
                "1 Get all\n2 GetById\n3 Create new\n4 Update\n5 exit");
                option = Int32.Parse(Console.ReadLine());
                

                switch (option)
                {
                    case 1:
                       var results = await client.GetAsync();
                       ManageResult(results,"get");
                        break;
                    case 2:
                        result = await client.GetAsync(GetId());
                        ManageResult(result, "get");
                        break;
                    case 3:
                       result = await client.PostAsync( BuildObjectByConsole<TObject>(obj));
                       ManageResult(result, "post");
                        break;
                    case 4:
                       result = await client.UpdateAsync( GetId(), BuildObjectByConsole<TObject>(obj));
                       ManageResult(result, "update");
                        break;        
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                break;

            }
        }

        public static void ManageResult(object result, string NameMethod){
            if(result != null)
                Console.WriteLine(result.ToString());
            else
                ErrorManagement(NameMethod);
        }
        public static void ManageResult<TObject>(IEnumerable<TObject> result, string NameMethod) {
        if(result!=null){
            foreach(var obj in result){
                Console.WriteLine(obj.ToString());
            }
        }else
            ErrorManagement(NameMethod);
        }

        public static void ErrorManagement(string method){
            Console.ForegroundColor = ConsoleColor.Red;
            switch(method){
                case "get":
                    Console.WriteLine("not found\n");
                    break;
                case "post":
                    Console.WriteLine("error while Saved\n");
                    break;
                case "update":
                    Console.WriteLine("error while updated\n");
                    break;
                default:
                    break;
            }
            Console.ResetColor();

        }

    public static TObject BuildObjectByConsole<TObject>(TObject obj)
        {
        Type t = obj.GetType();
            var properties =t.GetProperties();
            foreach(var pi in properties)
            {
                if(!Attribute.IsDefined(pi,typeof(SkipAttribute)))
                {
                    if(Attribute.IsDefined(pi,typeof(IsClassAttribute)))
                    {
                    var instanceComplexObj = Activator.CreateInstance(pi.PropertyType);
                    var complexObj = BuildObjectByConsole(instanceComplexObj);
                    pi.SetValue(obj,complexObj);
                    }
                    else
                    {
                        string propertyValue = ObtainValueOfUser(pi.Name);
                        var pit = pi.PropertyType;
                        pi.SetValue(obj, ParseValueToTheCorrect(pit, propertyValue));

                    }
                }
            }
        return obj;
        }
        public static object ParseValueToTheCorrect(object pit, string val){

            if ((Type)pit == typeof(int))
                return Int32.Parse(val);
            else if ((Type)pit == typeof(decimal))
                return Decimal.Parse(val);
            else
                return val;
        }

        public static string ObtainValueOfUser(string name){
            string value;
            Console.WriteLine($"write {name}");
            value = Console.ReadLine();
            return value;
        }
        public static string GetId()
        {
            string id;
            Console.WriteLine("Write id");
            id = Console.ReadLine();

            return id;
        }
        
    }

}
   
