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
            
            EnumEntities? option = null;
            do 
            {
                Console.WriteLine("Select an Entity option:\n"+BuildString(typeof(EnumEntities)));
                if(int.TryParse(Console.ReadLine(),out int  opt))
                    option =(EnumEntities) opt;
                
                switch (option)
                {
                    case EnumEntities.Comments:
                       await Crudmenu<Comment>(new Comment());
                        break;
                    case EnumEntities.Post:
                       await Crudmenu<Post>(new Post());
                        break;
                    case EnumEntities.Album:
                       await Crudmenu<Album>(new Album());
                        break;
                    case EnumEntities.Photo:
                       await Crudmenu<Photo>(new Photo());
                        break;
                    case EnumEntities.Todo:
                       await Crudmenu<Todo>(new Todo());
                        break;
                    case EnumEntities.User:
                      await Crudmenu<User>(new User());
                        break;
                    case EnumEntities.Exit:
                        Console.WriteLine("bye");
                        break;  
                    default:
                        option = EnumEntities.Exit;     
                        break;     
                }
            } while(option != null && option != EnumEntities.Exit);
        }
        static async  Task Crudmenu<TObject>(TObject obj)
        {
            var client = new JsonClient<TObject>();
            EnumCrud? option = null;
            var result =default(TObject);

            do
            {
                Console.WriteLine("Select an action:\n"+BuildString(typeof(EnumCrud)));

                if(int.TryParse(Console.ReadLine(),out int  opt))
                    option =(EnumCrud) opt;

                switch (option)
                {
                    case EnumCrud.Get:
                       var results = await client.GetAsync();
                       ManageResult(results, Method.Get);
                        break;
                    case EnumCrud.GetById:
                        result = await client.GetAsync(GetId());
                        ManageResult(result, Method.Get);
                        break;
                    case EnumCrud.Post:
                       result = await client.PostAsync( BuildObjectByConsole<TObject>(obj));
                       ManageResult(result, Method.Post);
                        break;
                    case EnumCrud.Put:
                       result = await client.UpdateAsync( GetId(), BuildObjectByConsole<TObject>(obj));
                       ManageResult(result, Method.Put);
                        break;
                    case EnumCrud.Exit:
                        Console.WriteLine("return");
                        break;           
                    default:
                       option = EnumCrud.Exit;
                        break;
                }
                break;

            }while(option != null  && option != EnumCrud.Exit);
        }

        public static string BuildString(Type EnumType)
        {
            string result="";
            foreach(int res in Enum.GetValues(EnumType))
                result += $"{res} {Enum.GetName(EnumType, res)}{Environment.NewLine}";

            return result;
        }

        public static void ManageResult(object result, Method NameMethod){
            if(result != null)
                Console.WriteLine(result.ToString());
            else
                ErrorManagement(NameMethod);
        }
        public static void ManageResult<TObject>(IEnumerable<TObject> result, Method NameMethod) {
        if(result!=null){
            foreach(var obj in result){
                Console.WriteLine(obj.ToString());
            }
        }else
            ErrorManagement(NameMethod);
        }

        public static void ErrorManagement(Method method){
            Console.ForegroundColor = ConsoleColor.Red;
            switch(method){
                case Method.Get:
                    Console.WriteLine("not found\n");
                    break;
                case Method.Post:
                    Console.WriteLine("error while Saved\n");
                    break;
                case Method.Put:
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
        public static object ParseValueToTheCorrect(Type pit, string val){

            if (pit == typeof(int))
                return int.TryParse(val,out int res);
            else if (pit == typeof(decimal))
                return Decimal.TryParse(val, out Decimal res);
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
   
