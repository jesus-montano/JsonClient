using JsonClient.Attributes;
using JsonClient.Entities;
using JsonClient.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JsonClient
{
    class Program
    {

        static async Task Main(string[] args)
        {
            await RunClient();
        }

        private static async Task RunClient()
        {
            EntitiesEnum? option = null;
            do
            {
                Console.WriteLine("Select an Entity option:\n" + GetEnumValues<EntitiesEnum>());
                if (int.TryParse(Console.ReadLine(), out int opt))
                    option = (EntitiesEnum)opt;

                switch (option)
                {
                    case EntitiesEnum.Comments:
                        await Crudmenu<Comment>();
                        break;
                    case EntitiesEnum.Post:
                        await Crudmenu<Post>();
                        break;
                    case EntitiesEnum.Album:
                        await Crudmenu<Album>();
                        break;
                    case EntitiesEnum.Photo:
                        await Crudmenu<Photo>();
                        break;
                    case EntitiesEnum.Todo:
                        await Crudmenu<Todo>();
                        break;
                    case EntitiesEnum.User:
                        await Crudmenu<User>();
                        break;
                    case EntitiesEnum.Exit:
                        Console.WriteLine("bye");
                        break;
                    default:
                        option = EntitiesEnum.Exit;
                        break;
                }
            } while (option != null && option != EntitiesEnum.Exit);
        }

        private static async Task Crudmenu<TObject>() where TObject : EntityBase, new()
        {
            var client = new JsonClient<TObject>();
            RequestActionsEnum? option = null;
            var result = default(TObject);

            do
            {
                Console.WriteLine("Select an action:\n" + GetEnumValues<RequestActionsEnum>());

                if (int.TryParse(Console.ReadLine(), out int opt))
                    option = (RequestActionsEnum)opt;

                switch (option)
                {
                    case RequestActionsEnum.Get:
                        var results = await client.GetAsync();
                        ManageResult(results, Method.Get);
                        break;
                    case RequestActionsEnum.GetById:
                        result = await client.GetAsync(PromptValue("Write id"));
                        ManageResult(result, Method.Get);
                        break;
                    case RequestActionsEnum.Post:
                        result = await client.PostAsync(BuildObjectByConsole<TObject>());
                        ManageResult(result, Method.Post);
                        break;
                    case RequestActionsEnum.Put:
                        result = await client.UpdateAsync(PromptValue("Write id"), BuildObjectByConsole<TObject>());
                        ManageResult(result, Method.Put);
                        break;
                    case RequestActionsEnum.Exit:
                        Console.WriteLine("return");
                        break;
                    default:
                        option = RequestActionsEnum.Exit;
                        break;
                }

            } while (option != null && option != RequestActionsEnum.Exit);
        }

        private static string GetEnumValues<TEnum>() where TEnum : Enum
        {
            var result = new StringBuilder();
            var enumValues = Enum.GetValues(typeof(TEnum));

            foreach (TEnum res in enumValues)
            {
                var value = Convert.ChangeType(res, typeof(int));
                var displayName = res.GetDisplayName();
                result.AppendLine($"{value} {displayName}");
            }

            return result.ToString();
        }

        private static void ManageResult(object result, Method NameMethod)
        {
            if (result != null)
                Console.WriteLine(result.ToString());
            else
                WriteError(NameMethod);
        }

        private static void ManageResult<TObject>(IEnumerable<TObject> result, Method NameMethod)
        {
            if (result != null)
            {
                foreach (var obj in result)
                    Console.WriteLine(obj.ToString());
            }
            else
                WriteError(NameMethod);
        }

        private static void WriteError(Method method)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            switch (method)
            {
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

        private static TObject BuildObjectByConsole<TObject>(TObject inputObject = null) where TObject : EntityBase
        {
            TObject obj = inputObject ?? Activator.CreateInstance<TObject>();
            Type t = obj.GetType();
            var properties = t.GetProperties();
            foreach (var pi in properties)
            {
                if (!pi.HasAttribute<SkipAttribute>())
                {
                    if (pi.HasAttribute<IsClassAttribute>())
                    {
                        var instanceComplexObj = Activator.CreateInstance(pi.PropertyType);
                        var complexObj = BuildObjectByConsole(instanceComplexObj as EntityBase);
                        pi.SetValue(obj, complexObj);
                    }
                    else
                    {
                        string propertyValue = PromptValue($"write {pi.Name}");
                        var pit = pi.PropertyType;
                        pi.SetValue(obj, ParseString(pit, propertyValue));
                    }
                }
            }
            return obj;
        }

        private static object ParseString(Type type, string value)
        {
            if (type == typeof(int) && int.TryParse(value, out int intValue))
                return intValue;
            else if (type == typeof(decimal) && decimal.TryParse(value, out decimal decimalValue))
                return decimalValue;
            else
                return value;
        }

        private static string PromptValue(string message)
        {
            Console.WriteLine($"{message} > ");
            return Console.ReadLine();
        }
    }
}

