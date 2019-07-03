using System.ComponentModel;
namespace JsonClient{
  public enum Method
  {
    Get,
    Post, 
    Put
  };
  public enum EnumEntities
  {
     Comments = 1,
     Post = 2,
     Album = 3,
     Photo = 4,
     Todo = 5,
     User = 6,
     Exit = 7
  }

  public enum EnumCrud
  {
    [Description("Get All")]
    Get = 1,
    [Description("Get All")]
    GetById = 2,
    [Description("Add new")]
    Post = 3,
    [Description("Update")]
    Put = 4,
    [Description("Exit")]
    Exit = 5
  }
  
}
