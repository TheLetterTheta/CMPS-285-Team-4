using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBC
{/*
    public class Feed
    {
        public string Data { get; set; }
        public string Paging { get; set; }
        public string Story { get; set; }
        public string Message { get; set; }
        public string Id { get; set; }
    }
*/


    public class Feed
    {
        public List<Data> Data { get; set; }
        public Paging Paging { get; set; }
    }

    public class Data
    {
        public string Picture { get; set; }
        public string Message { get; set; }

        //public string Created_Time { get; set; }
        public string Id { get; set; }
    }

    public class Paging
    {
        public string Previous { get; set; }
        public string Next { get; set; }
    }

    public class RootObject
    {
        public Feed Feed { get; set; }
        public string Id { get; set; }
    }

}


/*
public class Posts
{
public dynamic JsonObj { get; set; }
public Posts(dynamic json)
{
   JsonObj = json;
   Id = JsonObj.Id;
   Name = JsonObj.Name;
   Feed = new Feed(JsonObj.Feed);
}
public string Id { get; set; }
public string Name { get; set; }
public Feed Feed { get; set; }
}

public class Feed
{
public dynamic JsonObj { get; set; }
public Feed(dynamic json)
{
   JsonObj = json;

   if (JsonObj != null)
   {
       if(JsonObj.Data != null)
       {
           Data = new Post[JsonObj.Data.Length];
           for(int i = 0; i < Data.Length; i++)
           {
               Data[i] = new Post(JsonObj.Data[i]);
           }
       }
   }
}
public Post [] Data { get; set; }
//public string Paging { get; set; }
}

public class Post
{
public dynamic JsonObj { get; set; }
public Post(dynamic json)
{
   JsonObj = json;

   if (JsonObj != null)
   {
       if (JsonObj.Attachments != null)
       {
       }
   }
}


public string Id { get; set; }
public string Message { get; set; }
public string Story { get; set; }
public string Created_time { get; set; }
public Attachments Attachments { get; set; }

}

public class Attachments
{
public Attachments [] Data { get; set; }
}

public class Attachment
{
public string Description { get; set; }
public Media Media { get; set; }
public Target Target { get; set; }
public string Title { get; set; }
public string Type { get; set; }
public string Url { get; set; }

}

public class Media
{
public ImageItem Image{ get; set; }
}

public class ImageItem
{
public int Height { get; set; }
public int Width { get; set; }
public string Src { get; set; }
}

public class Target
{
public string Id { get; set; }
public string Url { get; set; }
}


}
*/
