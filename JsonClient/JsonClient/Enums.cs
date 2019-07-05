using System.ComponentModel.DataAnnotations;
using JsonClient.Attributes;
namespace JsonClient
{
    public enum Method
    {
        Get,
        Post,
        Put
    };
    public enum EntitiesEnum
    {
        Comments = 1,
        Post = 2,
        Album = 3,
        Photo = 4,
        Todo = 5,
        User = 6,
        Exit = 7
    }

    public enum RequestActionsEnum
    {
        [Display(Name = "Get By Name")]
        [SkipAttribute]
        GetByName =0,
        [Display(Name = "Get All")]
        Get = 1,
        [Display(Name = "Get by Id")]
        GetById = 2,
        [Display(Name = "Add new")]
        Post = 3,
        [Display(Name = "Update")]
        Put = 4,
        [Display(Name = "Exit")]
        Exit = 5
    }
}
